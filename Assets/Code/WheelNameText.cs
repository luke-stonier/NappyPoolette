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
