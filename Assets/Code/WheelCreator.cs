using System;
using System.Collections.Generic;
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

    void Start()
    {
        safeArrays();
        string[] names = new string[0];
        generateWheel();
    }

    private void safeArrays()
    {
        if (names.Length != MAXNAMES)
        {
            names = new string[MAXNAMES];
        }

        if (colours.Length != MAXCOLOURS)
        {
            colours = new Color[MAXCOLOURS];
        }
    }

    public void setNames(string[] _names)
    {
        names = _names;
        safeArrays();
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
        WheelOption[] wheelOptions = createNameArray();
        if (wheelOptions.Length == 0)
            wheelOptions = BlankOptions();

        int i = 0;
        foreach(WheelOption option in wheelOptions)
        {
            var segment = Instantiate(wheelSegment, transform.position, Quaternion.identity);
            WheelSegment ws = segment.gameObject.GetComponent<WheelSegment>();
            ws.AddName(option.name);
            ws.SetColour(option.colour);
            segment.transform.rotation = Quaternion.Euler(0,0, 60 * i);
            segment.transform.parent = gameObject.transform;
            segment.transform.name = $"{option.name} ({i})";
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

    private WheelOption[] BlankOptions()
    {
        var blankWheelOptions = new WheelOption[6];
        blankWheelOptions[0] = new WheelOption("", colours[0]);
        blankWheelOptions[1] = new WheelOption("", colours[1]);
        blankWheelOptions[2] = new WheelOption("", colours[0]);
        blankWheelOptions[3] = new WheelOption("", colours[1]);
        blankWheelOptions[4] = new WheelOption("", colours[0]);
        blankWheelOptions[5] = new WheelOption("", colours[1]);
        return blankWheelOptions;
    }
}