using System.Collections.Generic;

class SpawnDumbbell : SpawnPackage
{
    public override float SpawnTime { get; protected set; }
    public override List<BasePackage> ListBasePackage { get; protected set; }

    private readonly float _spawnTime = 14;

    public override void Initialization()
    {
        if (IocContainer.Instance.GameLevel.CurrentLevel.IsCanSpawnDumbbell)
        {
            SpawnTime = _spawnTime;
            _spawnTimer.TimeToCreate += Spawn;
            _spawnTimer.StartTimer(SpawnTime);
            ListBasePackage = new List<BasePackage>();
        }        
    }
}