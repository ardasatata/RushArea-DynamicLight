using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (PolygonLight))]
public class PolygonLightEditor : Editor
{
    void OnSceneGUI(){
        PolygonLight fow = (PolygonLight)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.right, 360, fow.lightRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.lightAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.lightAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.lightRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.lightRadius);
    }
}
