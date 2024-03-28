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
        
        meshManager = GetComponent<ARMeshManager>();
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
                Debug.Log("Yes button clicked");
                Application.Quit();
            })
            .SetNegative("No", (args) => Debug.Log("No button clicked"));

        dialog.Show();
    }

    private void ResetMeshManager()
    {
        try
        {
            meshManager.DestroyAllMeshes();
            var meshPrefab = meshManager.meshPrefab;
            if (meshPrefab != null)
            {
                Renderer meshRenderer = meshPrefab.GetComponent<Renderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = true;
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
    
    private void HideMeshRenderer()
    {
        try
        {
            var meshPrefab = meshManager.meshPrefab;
            if (meshPrefab != null)
            {
                Renderer meshRenderer = meshPrefab.GetComponent<Renderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = false;
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
    
    public void CreateRemapRoomDialog()
    {
        ResetMeshManager();
        IDialog dialog = dialogPool.Get()
            .SetHeader("Reset Mapping")
            .SetBody("Walk around to map your environment. After you are done mapping, click Finish Mapping.")
            .SetNeutral("Finish Mapping", (args) =>
            {
                HideMeshRenderer();
                Debug.Log("neutral button clicked");
            });
        dialog.Show();
    }
}
