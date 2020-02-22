using UnityEngine;

public class WheelSegment : MonoBehaviour
{

    public TextMesh nameTextMesh;
    public SpriteRenderer renderer;

    public void AddName(string name)
    {
        nameTextMesh.text = name;
    }

    public void SetColour(Color color)
    {
        renderer.color = color;
    }
}
