using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WheelNameText))]
public class WheelNameEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WheelNameText wnt = (WheelNameText)target;
        if (GUILayout.Button("Sort"))
        {
            wnt.setSort();
        }
    }
}
