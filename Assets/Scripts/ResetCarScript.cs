using UnityEngine;

public class ResetCarScript : MonoBehaviour
{
    private static Vector3 _spawnOffSet;
    [SerializeField] private string carName = "RaceCar_Blue";
    private GameObject _carGameObject;
    private Rigidbody _carRigidBody;
    private Vector3 _carSize;
    
    public void Awake()
    {
        _carGameObject = GameObject.Find(carName);
        _carRigidBody = _carGameObject.GetComponent<Rigidbody>();
        _carGameObject.SetActive(false);
    }

    public void ResetCar()
    {
        if (_carRigidBody == null) return;
        if (Camera.main == null) return;

        _carGameObject.SetActive(true);
        _carSize = _carGameObject.GetComponent<Collider>().bounds.size;
        _spawnOffSet = new Vector3(0, _carSize.y, _carSize.z);

        var rbTransform = _carRigidBody.transform;
        var cameraTransform = Camera.main.transform;
        var cameraPosition = cameraTransform.position;
        var cameraRotation = cameraTransform.rotation;

        rbTransform.position = cameraPosition + cameraTransform.forward * _spawnOffSet.z + new Vector3(0, _spawnOffSet.y, 0);
        rbTransform.rotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0);
        _carRigidBody.velocity = Vector3.zero;
        _carRigidBody.angularVelocity = Vector3.zero;
    }
}
