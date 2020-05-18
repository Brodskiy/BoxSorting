using UnityEngine;

public abstract class BaseGameElement : MonoBehaviour
{
    protected Vector3 _gameElementPosition;

    public abstract Vector3 GetSpawnPosition();
}