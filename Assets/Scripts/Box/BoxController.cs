using System;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject _backgroundColor;

    public BoxInfoData InfoData;

    private void Start()
    {
        InfoData = new BoxInfoData();
        InfoData.WasActive = true;
    }

    public void SetBoxColor(int quantityColors)
    {
        ChangColor changColor = new ChangColor(quantityColors);
        InfoData.BoxColor = changColor.RandomColor;
        GC.SuppressFinalize(changColor);
    }

    public void IsCaught(bool isCaught)
    {
        InfoData.WasCaught = isCaught;
    }

    public void IsActive(bool isActive)
    {
        InfoData.WasActive = gameObject.activeInHierarchy; // todo:
    }

    public void Activate(float _leftEdge, float _rightEdge, float _startPositionY)
    {
        transform.position = new Vector3(UnityEngine.Random.Range(_leftEdge, _rightEdge), _startPositionY);
        IsActive(true);
        IsCaught(false);
    }
}