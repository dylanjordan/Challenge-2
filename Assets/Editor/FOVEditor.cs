using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyAI))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyAI fov = (EnemyAI)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);
    }
}
