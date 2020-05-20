using UnityEngine;

public abstract class BasePackage : BaseGameElement
{
    public bool IsCanCougth { get; protected set; }
    public bool IsActive { get; protected set; }
    public Vector3 ScaleValue { get; set; }      

    public abstract void Activate();
    public abstract void Deactivation();
}