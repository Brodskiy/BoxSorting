using System.Collections.Generic;

public abstract class SpawnMobileObject : SpawnSystem
{
    public abstract float SpawnTime { get; protected set; }
    public abstract List<BasePackage> ListBasePackage { get; protected set; }

    protected float _timer;

    public abstract void Inicialization();
}