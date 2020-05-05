using UnityEngine;

public class SpawnFloor : MonoBehaviour, IInitializationSystem
{
    [SerializeField] private GameObject _floorPrefab;

    public void Initialization()
    {
        Instantiate(_floorPrefab);
    }
}