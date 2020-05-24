using System;

public interface ISpawnPackage : IInitializationSystem
{
    event Action Spawned;
}