using UnityEngine;
public abstract class MoveBasePackage : MonoBehaviour
{
    protected GameLevelInspector _gameLevelInspector;
    protected float _speed;

    protected abstract void Move();
}