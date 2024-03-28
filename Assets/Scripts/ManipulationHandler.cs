using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

/// <summary>
/// Script to handle the manipulation of objects in the scene.
/// Authors: Joseph Chun, Kira Yoon
/// Date: March 27, 2024
/// </summary>
public class ManipulationHandler : MonoBehaviour
{
    /// <summary>
    /// Set up instance variables.
    /// </summary>
    public MonoBehaviour[] scriptsToDisable;
    private ObjectManipulator objectManipulator;

    /// <summary>
    /// Called before the first frame update.
    /// </summary>
    private void Start()
    {
        objectManipulator = GetComponent<ObjectManipulator>();
    }

    /// <summary>
    /// Update is called once per frame. Disable scripts when object is grabbed.
    /// </summary>
    private void Update()
    {
        if (objectManipulator.IsGrabSelected)
        {
            foreach (var script in scriptsToDisable)
            {
                script.enabled = false;
            }
        } 
        else
        {
            foreach (var script in scriptsToDisable)
            {
                script.enabled = true;
            }
        }
    }
}