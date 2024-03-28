using UnityEngine;
using Slider = MixedReality.Toolkit.UX.Slider;

/// <summary>
/// Script to handle the sliders in the scene.
/// Authors: Joseph Chun, Kira Yoon
/// Date: March 27, 2024
/// Sources:
/// https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-uxcomponents/packages/uxcomponents/slider
/// </summary>
public class SliderScript : MonoBehaviour
{
    /// <summary>
    /// Set up instance variables.
    /// </summary>
    public Slider VerticalSlider;
    public Slider HorizontalSlider;
    
    /// <summary>
    /// Update is called once per frame. Reset the sliders when they are not being hovered over.
    /// </summary>
    private void Update()
    {
       ResetSlider();
    }

    /// <summary>
    /// Resets the sliders to their default values when they are not being hovered over.
    /// </summary>
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