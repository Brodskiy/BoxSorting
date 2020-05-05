using System;

public interface ILevelSystem : IInitializationSystem
{
    event Action<LevelModelBase> OnLevelComplit;
}