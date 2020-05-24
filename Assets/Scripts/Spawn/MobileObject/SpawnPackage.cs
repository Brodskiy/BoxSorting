using System;

public abstract class SpawnPackage : SpawnMobileObject, ISpawnPackage
{
    public event Action Spawned;

    protected void Spawn()
    {
        Spawned?.Invoke();
        foreach (var package in ListBasePackage)
        {
            if (package.IsActive == false)
            {
                package.Activate();
                return;
            }
        }

        var basePackage = SpawnObject<BasePackage>(_basePackage);
        ListBasePackage.Add(basePackage);
    }
}
