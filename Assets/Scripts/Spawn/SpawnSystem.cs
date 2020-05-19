using UnityEngine;

public abstract class SpawnSystem : MonoBehaviour
{
    [SerializeField] protected BaseGameElement _gameElementPref;

    public T SpawnObject<T>(BaseGameElement someObject) where T: class
    {
        var newObject = Instantiate(someObject, someObject.GetSpawnPosition(), Quaternion.identity) as T;
        return newObject;
    }
}