using UnityEngine;

public class BaseBox : BasePackage
{
    [SerializeField] private GameObject _boxBackgroundColor;

    public Color BoxColor { get; private set; }


    public override Vector3 GetSpawnPosition()
    {
        throw new System.NotImplementedException();
    }

    public void SetBoxColor(Color color)
    {
        BoxColor = color;
        _boxBackgroundColor.GetComponent<Renderer>().material.color = BoxColor;
    }
}