using UnityEngine;

public class SpawnFloorView : MonoBehaviour, IContainerSystem
{
    [SerializeField] private GameObject _floorPrefab;

    public void Init()
    {
        gameObject.SetActive(true);
        Instantiate(_floorPrefab);
    }
}