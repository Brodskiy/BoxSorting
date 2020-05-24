using System;
using UnityEngine;

public class BaseBoxView : BasePackage
{
    [SerializeField] private Renderer _boxBackgroundColor;

    public Color BoxColor { get; private set; }
    public bool IsWasCaught { get; private set; }

    private Vector3 _startScale = new Vector3(0.4f, 0.4f);

    private void Awake()
    {
        SetRandomColor();
        EPackage = EPackageElement.Box;
    }

    public override void Activate()
    {        
        PackageActive(true);
    }

    public override void Deactivation()
    {
        transform.position = RandomStartPosition();
        SetRandomColor();
        PackageActive(false);
        IsCaught(false);
        transform.localScale = _startScale;
    }

    public void IsCaught(bool isCaught)
    {
        IsWasCaught = isCaught;
    } 

    private void SetRandomColor()
    {
        GererationColorSystem changColor = 
            new GererationColorSystem(IocContainer.Instance.GameLevel.CurrentLevel.QuantityColors);

        BoxColor = changColor.RandomColor;
        _boxBackgroundColor.material.color = BoxColor;
        GC.SuppressFinalize(changColor);
    }
}