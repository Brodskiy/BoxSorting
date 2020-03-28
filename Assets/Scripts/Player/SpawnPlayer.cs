using UnityEngine;

public class SpawnPlayer : MonoBehaviour, IContainerSystem
{
    [SerializeField] private GameObject _playerPrefab;

    public void Init()
    {
        gameObject.SetActive(true);

        Instantiate(_playerPrefab);
    }
}