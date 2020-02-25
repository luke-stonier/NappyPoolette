using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WheelCreator))]
public class WheelBuilderEditor : Editor
{
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            WheelCreator wc = (WheelCreator)target;
            if (GUILayout.Button("Build"))
            {
                string[] names = new string[0];
                wc.generateWheel();
            }
        }
}
