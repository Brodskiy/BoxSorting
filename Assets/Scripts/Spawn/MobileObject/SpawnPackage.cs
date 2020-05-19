using System.Collections.Generic;
using UnityEngine;

public class SpawnPackage : SpawnMobileObject
{
    const float ZERO = 0;
    public override List<BasePackage> ListBasePackage { get; protected set; }
    public override float SpawnTime { get; protected set; }

    public Vector3 MinPosition => IocContainer.Instance.ScreenSystem.MinPosition;
    public Vector3 MaxPosition => IocContainer.Instance.ScreenSystem.MaxPosition;

    public override void Inicialization()
    {
        ListBasePackage = new List<BasePackage>();
        SpawnTime = IocContainer.Instance.GameLevel.CurrentLevel.TimeSpawnBox;
    }

    private void Update()
    {
        if(_timer >= SpawnTime)
        {
            Spawn();
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void Spawn()
    {
        _timer = ZERO;

        foreach (var package in ListBasePackage)
        {
            if (package.IsActive == false)
            {
                package.Activate(MinPosition.x, MaxPosition.x, MaxPosition.y);
                return;
            }
        }

        var basePackage = SpawnObject<BasePackage>(_gameElementPref);
        ListBasePackage.Add(basePackage);
    }
}
