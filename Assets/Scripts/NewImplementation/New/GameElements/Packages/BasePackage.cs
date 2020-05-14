using UnityEngine;

public abstract class BasePackage : BaseGameElement
{
    [SerializeField] protected float _speed;
    public bool IsCanCougth { get; protected set; }
    public bool IsActive { get; set; }
}