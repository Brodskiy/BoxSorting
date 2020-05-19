using UnityEngine;

public class BaseBoxView : BasePackage
{
    [SerializeField] private GameObject _boxBackgroundColor;

    public Color BoxColor { get; private set; }
    public bool IsCaught { get; set; }

    public override void Activate(float _leftEdge, float _rightEdge, float _startPositionY)
    {
        transform.position = new Vector3(UnityEngine.Random.Range(_leftEdge, _rightEdge), _startPositionY);

        IsActive = true;
        IsCaught = false;
    }

    public override Vector3 GetSpawnPosition()
    {
        return Vector3.zero;
    }

    //public void SetBoxColor(Color color)
    //{
    //    BoxColor = color;
    //    _boxBackgroundColor.GetComponent<Renderer>().material.color = BoxColor;
    //}

    //public void SetBoxColor(int quantityColors)
    //{
    //    GererationColorSystem changColor = new GererationColorSystem(quantityColors);
    //    InfoData.BoxColor = changColor.RandomColor;
    //    GC.SuppressFinalize(changColor);
    //}

    //public void IsCaught(bool isCaught)
    //{
    //    InfoData.WasCaught = isCaught;
    //}

    //public void IsActive(bool isActive)
    //{
    //    gameObject.SetActive(isActive);
    //    InfoData.WasActive = isActive;
}
