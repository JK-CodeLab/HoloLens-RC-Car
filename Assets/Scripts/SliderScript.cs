using System;
using System.Collections;
using System.Collections.Generic;
using MixedReality.Toolkit.SpatialManipulation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Slider = MixedReality.Toolkit.UX.Slider;

public class SliderScript : MonoBehaviour
{
    public Slider VerticalSlider;
    public Slider HorizontalSlider;
    
    private void Update()
    {
       ResetSlider();
    }

    private void ResetSlider()
    {
        if (!VerticalSlider.IsActiveHovered)
        {
            VerticalSlider.Value = 0f;
        }
        if (!HorizontalSlider.IsActiveHovered)
        {
            HorizontalSlider.Value = 0f;
        }
    }
}