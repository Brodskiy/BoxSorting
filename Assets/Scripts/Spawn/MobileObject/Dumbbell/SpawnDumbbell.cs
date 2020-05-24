using System.Collections.Generic;

class SpawnDumbbell : SpawnPackage
{
    public override float SpawnTime { get; protected set; }
    public override List<BasePackage> ListBasePackage { get; protected set; }

    public override void Initialization()
    {
        if (IocContainer.Instance.GameLevel.CurrentLevel.IsCanSpawnDumbbell)
        {
            SpawnTime = 15;
            _spawnTimer.TimeToCreate += Spawn;
            _spawnTimer.StartTimer(SpawnTime);
            ListBasePackage = new List<BasePackage>();
        }        
    }
}