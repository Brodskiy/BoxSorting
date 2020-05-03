using System;

public interface ISpawnComplit : IContainerSystem, ISpawn
{
    event Action SpawnComplit;
}