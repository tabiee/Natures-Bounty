using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
    public Color gizmoColor = Color.yellow; // Color of the gizmo
    public float gizmoSize = 0.5f; // Size of the gizmo

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor; // Set the color of the gizmo

        // Draw a wireframe circle to indicate the position in 2D space
        DrawWireCircle(transform.position, gizmoSize);
    }

    void DrawWireCircle(Vector3 position, float radius)
    {
        int segments = 20;
        float angle = 0f;

        Vector3 lastPoint = position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        for (int i = 1; i <= segments; i++)
        {
            angle = i * 2 * Mathf.PI / segments;
            Vector3 nextPoint = position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Gizmos.DrawLine(lastPoint, nextPoint);
            lastPoint = nextPoint;
        }
    }
}
