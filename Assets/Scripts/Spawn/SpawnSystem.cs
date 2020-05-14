using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public T SpawnObject<T>(BaseGameElement someObject) where T: class
    {
        var newObject = Instantiate(someObject, someObject.GetStartPosition()) as T;
        return newObject;
    }
}