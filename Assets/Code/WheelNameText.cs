using UnityEditor;
using UnityEngine;

public class WheelNameText : MonoBehaviour
{
    public string MySortingLayer;
    public int MySortingOrderInLayer;

    public void setSort()
    {
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = MySortingLayer;
        renderer.sortingOrder = MySortingOrderInLayer;
    }
}

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
