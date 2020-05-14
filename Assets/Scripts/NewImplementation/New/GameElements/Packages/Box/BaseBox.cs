using UnityEngine;

public class BaseBox : BasePackage
{
    [SerializeField] private GameObject _boxBackgroundColor;

    public Color BoxColor { get; private set; }

    public void SetBoxColor(Color color)
    {
        BoxColor = color;
        _boxBackgroundColor.GetComponent<Renderer>().material.color = BoxColor;
    }
}