using UnityEngine;

public abstract class SpawnStillObject : SpawnSystem, IInitializationSystem
{
    [SerializeField] protected BaseGameElement _gameElementPref;
    public abstract void Initialization();
}