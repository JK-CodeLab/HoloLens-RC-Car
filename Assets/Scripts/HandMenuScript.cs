using System;
using System.Collections;
using System.Collections.Generic;
using MixedReality.Toolkit.UX;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class HandMenuScript : MonoBehaviour
{
    public DialogPool dialogPool;

    public ARMeshManager meshManager;
    
    private static Vector3 _spawnOffSet;
    [SerializeField] private string carName = "RaceCar_Blue";
    private GameObject _carGameObject;
    private Rigidbody _carRigidBody;
    private Vector3 _carSize;
    
    void Awake()
    {
        if (dialogPool == null)
        {
            dialogPool = GetComponent<DialogPool>();
        }
        
        _carGameObject = GameObject.Find(carName);
        _carRigidBody = _carGameObject.GetComponent<Rigidbody>();
        _carGameObject.SetActive(false);
    }
    

    
    public void ResetCar()
    {
        if (_carRigidBody == null || Camera.main == null) return;

        _carGameObject.SetActive(true);
        _carSize = _carGameObject.GetComponent<Collider>().bounds.size;
        _spawnOffSet = new Vector3(0, _carSize.y, _carSize.z * 3);

        var rbTransform = _carRigidBody.transform;
        var cameraTransform = Camera.main.transform;
        var cameraPosition = cameraTransform.position;
        var cameraRotation = cameraTransform.rotation;

        rbTransform.position = cameraPosition + cameraTransform.forward * _spawnOffSet.z + new Vector3(0, _spawnOffSet.y, 0);
        rbTransform.rotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0);
        _carRigidBody.velocity = Vector3.zero;
        _carRigidBody.angularVelocity = Vector3.zero;
    }

    public void CreateExitDialog()
    {
        IDialog dialog = dialogPool.Get()
            .SetHeader("Exit Game")
            .SetBody("Are you sure you want to exit?")
            .SetPositive("Yes", (args) =>
            {
                Application.Quit();
            })
            .SetNegative("No");

        dialog.Show();
    }

    private void ShowMeshManager(bool state)
    {
        try
        {
            meshManager.meshPrefab.GetComponent<Renderer>().enabled = state;
            
            var meshes = meshManager.meshes;
            foreach (var meshFilter in meshes)
            {
                meshFilter.GetComponent<Renderer>().enabled = state;
            }
            
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    /// <summary>
    /// Source: https://forum.unity.com/threads/how-to-reset-meshes-generated-by-armeshmanager.1451887/
    /// Only way to reset the mesh manager is to disable and enable it
    /// </summary>
    public void ResetMeshManager()
    {
        try
        {
            meshManager.enabled = false;
            meshManager.DestroyAllMeshes();
            ShowMeshManager(true);
            meshManager.enabled = true;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    
    public void CreateRemapRoomDialog()
    {
        IDialog dialog = dialogPool.Get()
            .SetHeader("Reset Mapping")
            .SetBody("Walk around to map your environment. After you are done mapping, click Finish Mapping.")
            .SetNeutral("Finish Mapping", (args) =>
            {
                meshManager.enabled = false;
                ShowMeshManager(false);
                meshManager.enabled = true;
            });
        dialog.Show();
    }
}
