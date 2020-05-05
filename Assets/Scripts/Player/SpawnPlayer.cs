using UnityEngine;

public class SpawnPlayer : MonoBehaviour, IInitializationSystem
{
    [SerializeField] private PlayerView _playerPrefab;

    public void Initialization()
    {
        Instantiate(_playerPrefab.gameObject);
    }
}