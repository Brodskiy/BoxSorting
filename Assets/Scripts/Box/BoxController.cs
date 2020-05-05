using System;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public BoxInfo InfoData { get; private set;}

    public void Init()
    {
        InfoData = new BoxInfo();
    }

    public void Activate(float _leftEdge, float _rightEdge, float _startPositionY)
    {
        transform.position = new Vector3(UnityEngine.Random.Range(_leftEdge, _rightEdge), _startPositionY);

        IsActive(true);
        IsCaught(false);
    }

    public void SetBoxColor(int quantityColors)
    {
        GererationColorSystem changColor = new GererationColorSystem(quantityColors);
        InfoData. BoxColor = changColor.RandomColor;
        GC.SuppressFinalize(changColor);
    }

    public void IsCaught(bool isCaught)
    {
        InfoData.WasCaught = isCaught;
    }

    public void IsActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        InfoData.WasActive = isActive;
    }    
}