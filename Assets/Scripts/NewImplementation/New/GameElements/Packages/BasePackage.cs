using UnityEngine;

public abstract class BasePackage : BaseGameElement
{
    [SerializeField] protected float _speed;

    public bool IsCanCougth { get; protected set; }
    public bool IsActive { get; set; }
    public Vector3 ScaleValue { get; set; }      

    public abstract void Activate(float _leftEdge, float _rightEdge, float _startPositionY);
}