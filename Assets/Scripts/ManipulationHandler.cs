using System;
using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;

public class ManipulationHandler : MonoBehaviour
{
    public MonoBehaviour[] scriptsToDisable;
    private ObjectManipulator objectManipulator;

    private void Start()
    {
        objectManipulator = GetComponent<ObjectManipulator>();
    }

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