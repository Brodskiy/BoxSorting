using UnityEngine;

public abstract class BasePackage : BaseGameElement
{
    public bool IsCanCougth { get; protected set; }
    public bool IsActive { get; protected set; }
    public Vector3 ScaleValue { get; set; }
    public EPackageElement EPackage { get; set; }

    public float SpawnTime { get; protected set; }

    protected IScreenInfoSystem _screenInfo;

    public abstract void Activate();
    public abstract void Deactivation();

    public override Vector3 GetSpawnPosition()
    {
        return RandomStartPosition();
    }

    protected Vector3 RandomStartPosition()
    {
        _screenInfo = IocContainer.Instance.ScreenSystem;

        return new Vector3(
            Random.Range(_screenInfo.MinPosition.x, _screenInfo.MaxPosition.x),
            _screenInfo.MaxPosition.y);
    }

    protected void PackageActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        IsActive = isActive;
    }
}