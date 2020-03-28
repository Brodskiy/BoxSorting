using System;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    public GameObject _backgroundColor;
    public Color BoxColor { get; private set; }
    public bool WasCaught { get; private set; }
    public bool WasActive { get; private set; }

    private void Start()
    {
        WasActive = true;
    }

    public void SetBoxColor(int quantityColors)
    {
        ChangColor changColor = new ChangColor(quantityColors);
        BoxColor = changColor.RandomColor;
        GC.SuppressFinalize(changColor);
    }

    public void IsCaught(bool isCaught)
    {
        WasCaught = isCaught;
    }

    public void IsActive(bool isActive)
    {
        WasActive = isActive;
        gameObject.SetActive(isActive);
    }

    public void Activate(float _leftEdge, float _rightEdge, float _startPositionY)
    {
        transform.position = new Vector3(UnityEngine.Random.Range(_leftEdge, _rightEdge), _startPositionY);
        IsActive(true);
        IsCaught(false);
    }
}