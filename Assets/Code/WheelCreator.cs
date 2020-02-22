using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WheelOption
{
    public string name;
    public Color colour;

    public WheelOption(string _name, Color _colour)
    {
        name = _name;
        colour = _colour;
    }
}

public class WheelCreator : MonoBehaviour
{
    private const int MAXNAMES = 6;
    private const int MAXCOLOURS = 2;

    public Transform wheelSegment;
    public string[] names = new string[MAXNAMES];
    public Color[] colours = new Color[MAXCOLOURS];

    void OnValidate()
    {
        if (names.Length != MAXNAMES)
        {
            Array.Resize(ref names, MAXNAMES);
        }

        if (colours.Length != MAXCOLOURS)
        {
            Array.Resize(ref colours, MAXCOLOURS);
        }
    }

    void Start()
    {
        string[] names = new string[0];
        generateWheel();
    }

    public void setNames(string[] _names)
    {
        names = _names;
        OnValidate();
        generateWheel();
    }

    public void generateWheel()
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        foreach (Transform child in children)
        {
            DestroyImmediate(child.gameObject, true);
        }

        // create Names
        WheelOption[] orderNames = createNameArray();
        if (orderNames.Length == 0)
            return;

        int i = 0;
        foreach(WheelOption option in orderNames)
        {
            var segment = Instantiate(wheelSegment, transform.position, Quaternion.identity);
            WheelSegment ws = segment.gameObject.GetComponent<WheelSegment>();
            ws.AddName(option.name);
            ws.SetColour(option.colour);
            segment.transform.rotation = Quaternion.Euler(0,0, 60 * i);
            segment.transform.parent = gameObject.transform;
            i++;
        }
    }

    private WheelOption[] createNameArray()
    {
        bool anyNames = false;
        foreach (string name in names)
        {
            if (name != "")
                anyNames = true;
        }

        if (!anyNames) return new WheelOption[0];

        List<WheelOption> optionArray = new List<WheelOption>();
        while (optionArray.Count < 6)
        {
            var i = 0;
            foreach (string name in names)
            {
                if (name == "" || name == null) { continue; }
                Color colour = i % 2 == 0 ? colours[0] : colours[1];
                optionArray.Add(new WheelOption(name, colour));
                i++;
            }
        }
        return optionArray.ToArray();
    }
}

[CustomEditor(typeof(WheelCreator))]
public class WheelCreatorEditor : Editor
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
