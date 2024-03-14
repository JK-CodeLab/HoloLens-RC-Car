using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MixedReality.Toolkit.UX;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Class to control the car in the game.
/// Source: https://www.youtube.com/watch?v=Z4HA8zJhGEk&ab_channel=GameDevChef
/// </summary>
public class CarController : MonoBehaviour
{
    private Slider _verticalSlider;
    private Slider _horizontalSlider;
    
    private Rigidbody _carRigidBody;
    private GameObject _carModel;

    private float _verticalInput;
    private float _horizontalInput;
    private float _currentSteerAngle;
    
    private const float MotorForce = 750;
    private const float MaxSteerAngle = 15;
    private float _lastVerticalTime;

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
        SetCenterOfMass();
    }
    
    private void SetCenterOfMass()
    {
        var centerOfMass = _carRigidBody.centerOfMass;
        centerOfMass.y *= 0.5f;
        _carRigidBody.centerOfMass = centerOfMass;
    }

    private void FixedUpdate()
    {
        _horizontalInput = _horizontalSlider.Value;
        _verticalInput = _verticalSlider.Value;
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        ResetCarIfUpdsideDown();
    }
    
    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = _verticalInput * MotorForce;
        frontRightWheelCollider.motorTorque = _verticalInput * MotorForce;
    }
    
    private void HandleSteering()
    {
        _currentSteerAngle = MaxSteerAngle * _horizontalInput;
        frontLeftWheelCollider.steerAngle = _currentSteerAngle;
        frontRightWheelCollider.steerAngle = _currentSteerAngle;
    }
    
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }
    
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        wheelCollider.GetWorldPose(out var pos, out var rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

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

    private bool FlipCar()
    {
        var transformUp = transform.up;
        if (_carRigidBody.velocity.magnitude > 0.01f)
        {
            return false;
        } 
        if (transformUp.y < 0)
        {
            _carRigidBody.AddForce(Vector3.up * 2500, ForceMode.Impulse);
            StartCoroutine(WaitAndRotate());
            return true;
        }
        switch (transformUp.x)
        {
            case > 0.75f:
                _carRigidBody.AddTorque(Vector3.forward * 100, ForceMode.Impulse);        
                return true;
            case < -0.75f:
                _carRigidBody.AddTorque(Vector3.back * 100, ForceMode.Impulse);
                return true;
            default:
                return false;
        }
    }
    
    private IEnumerator WaitAndRotate()
    {
        yield return new WaitForSeconds(0.1f);
        _carRigidBody.AddTorque(Vector3.forward * 100, ForceMode.Impulse);
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