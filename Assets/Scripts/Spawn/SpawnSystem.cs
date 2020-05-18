using UnityEngine;

public abstract class SpawnSystem : MonoBehaviour
{
    public T SpawnObject<T>(BaseGameElement someObject) where T: class
    {
        var newObject = Instantiate(someObject, someObject.GetSpawnPosition(), Quaternion.identity) as T;
        return newObject;
    }
}