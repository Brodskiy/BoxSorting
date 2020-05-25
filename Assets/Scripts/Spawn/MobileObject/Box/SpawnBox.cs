using System;
using System.Collections.Generic;

public class SpawnBox : SpawnPackage
{
    public override float SpawnTime { get; protected set; }
    public override List<BasePackage> ListBasePackage { get ; protected set; }

    public override void Initialization() 
    {
        SpawnTime = IocContainer.Instance.GameLevel.CurrentLevel.TimeSpawnBox;
        _spawnTimer.TimeToCreate += Spawn;
        _spawnTimer.StartTimer(SpawnTime);       
        ListBasePackage = new List<BasePackage>();
    }
}