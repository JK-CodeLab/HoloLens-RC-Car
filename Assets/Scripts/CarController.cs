using System;
using System.Collections;
using System.Collections.Generic;
using MixedReality.Toolkit.UX;
using UnityEngine;

/// <summary>
/// Class to control the car in the game.
/// </summary>
public class CarController : MonoBehaviour
{
    public Slider VerticalSlider;
    public Slider HorizontalSlider;
    public GameObject carObject;
    private const float RotationModifier = 0.05f;
    private const float ZSpeedModifier = 1.7f;
    private const float Gravity = 0f;
    private float _zSpeed;
    private float _xSpeed;
    private float _rotation;
    private float _previousTime;

    /// <summary>
    /// Start method to initialize the car controller.
    /// </summary>
    public void Start()
    {
        VerticalSlider.OnValueUpdated.AddListener(delegate { SetZSpeed(VerticalSlider.Value); });
        HorizontalSlider.OnValueUpdated.AddListener(delegate { SetRotation(HorizontalSlider.Value); });
    }

    /// <summary>
    /// Update method to update the car's position and rotation every frame. 
    /// </summary>
    private void Update()
    {
        var currentTime = Time.time;
        var timeDelta = currentTime - _previousTime;
        _previousTime = currentTime;
        
        carObject.transform.Translate(Vector3.forward * (_zSpeed * timeDelta));
        carObject.transform.Translate(Vector3.down * (Gravity * timeDelta));
        carObject.transform.Rotate(Vector3.up, _rotation, Space.Self);
    }

    /// <summary>
    /// Set the speed of the car in the z direction.
    /// </summary>
    /// <param name="zValue"></param>
    public void SetZSpeed(float zValue)
    {
        _zSpeed = zValue * ZSpeedModifier;
    }

    /// <summary>
    /// Set the speed of the car in the x direction.
    /// </summary>
    /// <param name="xValue"></param>
    public void SetRotation(float xValue)
    {
        _rotation = xValue * RotationModifier;
    }
    
    /// <summary>
    /// OnDestroy method to remove all listeners from the sliders.
    /// </summary>
    public void OnDestroy()
    {
        VerticalSlider.OnValueUpdated.RemoveAllListeners();
        HorizontalSlider.OnValueUpdated.RemoveAllListeners();
    }
}