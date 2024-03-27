using UnityEngine;

[ExecuteInEditMode] // This script will execute in Edit mode as well
public class ShowCenterOfMass : MonoBehaviour
{
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