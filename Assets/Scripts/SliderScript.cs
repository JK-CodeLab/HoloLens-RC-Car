using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Slider = MixedReality.Toolkit.UX.Slider;

public class SliderScript : MonoBehaviour
{
    public Slider Slider;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Update()
    {
        // if (!Slider.IsGrabSelected)
        // {
        //     Slider.Value = 0f;
        // }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!Slider.IsGrabSelected) 
        {
            Slider.Value = 0f; 
        }
    }
}