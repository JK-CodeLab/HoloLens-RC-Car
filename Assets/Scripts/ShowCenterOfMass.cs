using UnityEngine;

/// <summary>
/// Script to show the center of mass of a Rigidbody in the editor. Used for debugging.
/// Author: Joseph Chun, Kira Yoon
/// Date: March 27, 2024
/// Sources:
/// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html
/// </summary>
[ExecuteInEditMode]
public class ShowCenterOfMass : MonoBehaviour
{
    /// <summary>
    /// Collects the Rigidbody component and draws a red sphere at the center of mass.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(rb.transform.TransformPoint(rb.centerOfMass), 0.1f);
        }
    }
}