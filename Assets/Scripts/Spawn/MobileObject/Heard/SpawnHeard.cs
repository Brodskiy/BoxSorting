using System.Collections.Generic;

public class SpawnHeard : SpawnPackage
{
    public override float SpawnTime { get; protected set; }
    public override List<BasePackage> ListBasePackage { get; protected set; }

    public override void Initialization()
    {
        if (IocContainer.Instance.GameLevel.CurrentLevel.IsCanSpawnHeard)
        {
            SpawnTime = 5;
            _spawnTimer.TimeToCreate += Spawn;
            _spawnTimer.StartTimer(SpawnTime);
            ListBasePackage = new List<BasePackage>();
        }        
    }
}