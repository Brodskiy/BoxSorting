using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnMobileObject : SpawnSystem
{
    [SerializeField] protected SpawnTimer _spawnTimer;
    [SerializeField] protected BasePackage _basePackage;

    public abstract float SpawnTime { get; protected set; }
    public abstract List<BasePackage> ListBasePackage { get; protected set; }   

    public abstract void Initialization();
}