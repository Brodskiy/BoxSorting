using UnityEngine;

public abstract class BaseGameElement : MonoBehaviour
{
    protected Vector3 _spawnPosition;

    public abstract Vector3 GetSpawnPosition();
}