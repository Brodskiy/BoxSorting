using System;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public BoxInfo InfoData;

    private void Init() => InfoData = gameObject.AddComponent<BoxInfo>();

    public void SetBoxColor(int quantityColors)
    {
        Init();

        GererationColorSystem changColor = new GererationColorSystem(quantityColors);
        InfoData.BoxColor = changColor.RandomColor;
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

    public void Activate(float _leftEdge, float _rightEdge, float _startPositionY)
    {
        transform.position = new Vector3(UnityEngine.Random.Range(_leftEdge, _rightEdge), _startPositionY);

        IsActive(true);
        IsCaught(false);
    }
}