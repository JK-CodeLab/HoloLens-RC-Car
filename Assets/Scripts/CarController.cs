using System.Collections;
using MixedReality.Toolkit.UX;
using UnityEngine;


/// <summary>
/// Class to control the car in the game.
/// Authors: Joseph Chun, Kira Yoon
/// Date: March 27, 2024
/// Sources:
/// https://www.youtube.com/watch?v=Z4HA8zJhGEk&ab_channel=GameDevChef
/// https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-uxcomponents/packages/uxcomponents/slider
/// https://docs.unity3d.com/Manual/class-WheelCollider.html
/// https://docs.unity3d.com/ScriptReference/Rigidbody.html
/// https://docs.unity3d.com/Manual/VectorCookbook.html
/// https://docs.unity3d.com/Manual/class-Quaternion.html
/// </summary>
public class CarController : MonoBehaviour
{
    /// <summary>
    /// Initialize private variables for the car controller.
    /// </summary>
    private Slider _verticalSlider;
    private Slider _horizontalSlider;
    
    private Rigidbody _carRigidBody;
    private GameObject _carModel;
    [SerializeField] private float carScale = 0.15f;

    private float _verticalInput;
    private float _horizontalInput;
    private float _currentSteerAngle;

    /// <summary>
    /// Modifiers for the car's motor and steering.
    /// </summary>
    [SerializeField] private float MotorForce = 550;
    [SerializeField] private float BrakeForce = 100;
    private const float MaxSteerAngle = 15;
    private float _lastVerticalTime;

    /// <summary>
    /// Fields for the wheel colliders and transforms of the car model.
    /// </summary>
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;


    /// <summary>
    /// Awake method to initialize the car controller.
    /// </summary>
    public void Awake()
    {
        _verticalSlider = GameObject.Find("VerticalSlider").GetComponent<Slider>();
        _horizontalSlider = GameObject.Find("HorizontalSlider").GetComponent<Slider>();
        _carRigidBody = GetComponent<Rigidbody>();
        ResetCarProperties();
    }
    
    /// <summary>
    /// Rescale the car and reset the center of mass.
    /// </summary>
    public void ResetCarProperties()
    {
        transform.localScale = new Vector3(carScale, carScale, carScale);
        _carRigidBody.ResetCenterOfMass();
    }

    /// <summary>
    /// FixedUpdate method to update the car's movement and rotation.
    /// </summary>
    private void FixedUpdate()
    {
        _horizontalInput = _horizontalSlider.Value;
        _verticalInput = _verticalSlider.Value;
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        ResetCarIfUpdsideDown();
    }
    
    /// <summary>
    /// Uses vertical input and wheel colliders to control the car's motor.
    /// </summary>
    private void HandleMotor()
    {
        if (_verticalInput == 0)
        {
            frontLeftWheelCollider.brakeTorque = BrakeForce;
            frontRightWheelCollider.brakeTorque = BrakeForce;
            frontLeftWheelCollider.motorTorque = 0;
            frontRightWheelCollider.motorTorque = 0;
        }
        else
        {
            frontLeftWheelCollider.brakeTorque = 0;
            frontRightWheelCollider.brakeTorque = 0;
            frontLeftWheelCollider.motorTorque = _verticalInput * MotorForce;
            frontRightWheelCollider.motorTorque = _verticalInput * MotorForce;
        }
    }
    
    /// <summary>
    /// Handles the steering of the car using horizontal input and wheel colliders.
    /// </summary>
    private void HandleSteering()
    {
        _currentSteerAngle = MaxSteerAngle * _horizontalInput;
        frontLeftWheelCollider.steerAngle = _currentSteerAngle;
        frontRightWheelCollider.steerAngle = _currentSteerAngle;
    }
    
    /// <summary>
    /// Update the wheels' position and rotation.
    /// </summary>
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }
    
    /// <summary>
    /// Update a single wheel's position and rotation.
    /// </summary>
    /// <param name="wheelCollider"></param>
    /// <param name="wheelTransform"></param>
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        wheelCollider.GetWorldPose(out var pos, out var rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    /// <summary>
    /// Determine if the car has been upside down for more than 3 seconds and reset the car.
    /// </summary>
    private void ResetCarIfUpdsideDown()
    {
        var currentTime = Time.time;
        if (currentTime - _lastVerticalTime < 3)
        {
            return;
        }
        bool flipCar = FlipCar();
        if (!flipCar)
        {
            _lastVerticalTime = currentTime;        
        }
    }

    /// <summary>
    /// Flip the car if it is upside down.
    /// </summary>
    /// <returns></returns>
    private bool FlipCar()
    {
        var transformUp = transform.up;
        if (_carRigidBody.velocity.magnitude > 0.01f)
        {
            return false;
        } 
        if (transformUp.y < 0)
        {
            _carRigidBody.AddForce(Vector3.up * 5000, ForceMode.Impulse);
            StartCoroutine(WaitAndRotate());
            return true;
        }
        switch (transformUp.x)
        {
            case > 0.75f:
                _carRigidBody.AddForce(Vector3.up * 5000, ForceMode.Impulse);
                StartCoroutine(WaitAndRotate(0.2f, 50));
                return true;
            case < -0.75f:
                _carRigidBody.AddForce(Vector3.up * 5000, ForceMode.Impulse);
                StartCoroutine(WaitAndRotate(0.2f,-50));
                return true;
            default:
                return false;
        }
    }
    
    /// <summary>
    /// Wait for a set amount of car and adds a rotation force to the car.
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="force"></param>
    /// <returns></returns>
    private IEnumerator WaitAndRotate(float delay = 0.1f, int force = 100)
    {
        yield return new WaitForSeconds(delay);
        _carRigidBody.AddTorque(Vector3.forward * force, ForceMode.Impulse);
    }
    
    /// <summary>
    /// OnDestroy method to remove all listeners from the sliders.
    /// </summary>
    public void OnDestroy()
    {
        _verticalSlider.OnValueUpdated.RemoveAllListeners();
        _horizontalSlider.OnValueUpdated.RemoveAllListeners();
    }
}