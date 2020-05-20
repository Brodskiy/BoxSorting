using System;
using UnityEngine;

public class BaseBoxView : BasePackage
{
    [SerializeField] private GameObject _boxBackgroundColor;

    public Color BoxColor { get; private set; }
    public bool IsWasCaught { get; private set; }

    private IScreenInfoSystem _screenInfo;
    private Vector3 _startScale = new Vector3(0.4f, 0.4f);

    private void Awake()
    {
        SetBoxColor();
    }

    public override void Activate()
    {
        _screenInfo = IocContainer.Instance.ScreenSystem;

        transform.position = new Vector3(
            UnityEngine.Random.Range(_screenInfo.MinPosition.x, _screenInfo.MaxPosition.x),
            _screenInfo.MaxPosition.y);
        SetBoxColor();

        BoxActive(true);
    }

    public override void Deactivation()
    {
        BoxActive(false);
        IsCaught(false);
        transform.localScale = _startScale;
    }

    public override Vector3 GetSpawnPosition()
    {
        _screenInfo = IocContainer.Instance.ScreenSystem;
        return new Vector3(
            UnityEngine.Random.Range(_screenInfo.MinPosition.x, _screenInfo.MaxPosition.x),
            _screenInfo.MaxPosition.y);
    }

    public void IsCaught(bool isCaught)
    {
        IsWasCaught = isCaught;
    }

    private void BoxActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        IsActive = isActive;
    }

    private void SetBoxColor()
    {
        GererationColorSystem changColor = new GererationColorSystem(IocContainer.Instance.GameLevel.CurrentLevel.QuantityColors);
        BoxColor = changColor.RandomColor;
        _boxBackgroundColor.GetComponent<Renderer>().material.color = BoxColor;
        GC.SuppressFinalize(changColor);
    }
}
