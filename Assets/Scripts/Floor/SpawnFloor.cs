using UnityEngine;

public class SpawnFloor : MonoBehaviour, IContainerSystem
{
    [SerializeField] private GameObject _floorPrefab;

    public void Init()
    {
        gameObject.SetActive(true);

        Instantiate(_floorPrefab);
    }
}
