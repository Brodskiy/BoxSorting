using UnityEngine;

public class BaseGameElement : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected Transform _startPosition;

    public GameObject GetPrefab()
    {
        return _prefab;
    }

    public Transform GetStartPosition()
    {
        return _startPosition;
    }
}