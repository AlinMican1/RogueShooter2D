using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (LineOfSight))]
public class FOV : Editor
{
    private void OnSceneGUI()
    {
        LineOfSight fov = (LineOfSight)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.right, 360, fov.SightRadius);

        Vector3 viewAngleA = fov.AngleFromDirection(-fov.Angle / 2, false);
        Vector3 viewAngleB = fov.AngleFromDirection(fov.Angle / 2, false);
        //Handles.DrawWireArc(fov.transform.position, Vector3.up, viewAngleA, fov.Angle, fov.SightRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.SightRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.SightRadius);
    }
}

