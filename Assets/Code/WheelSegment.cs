using UnityEngine;

public class WheelSegment : MonoBehaviour
{

    public TextMesh nameTextMesh;
    public SpriteRenderer renderer;
    public string name;

    public void AddName(string _name)
    {
        nameTextMesh.text = _name;
        name = _name;
    }

    public void SetColour(Color  color)
    {
        renderer.color = color;
    }
}
