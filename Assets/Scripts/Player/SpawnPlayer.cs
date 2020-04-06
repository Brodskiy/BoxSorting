using UnityEngine;

public class SpawnPlayer : MonoBehaviour, IContainerSystem
{
    [SerializeField] private PlayerMoves _playerPrefab;

    public void Init()
    {
        Instantiate(_playerPrefab.gameObject);
    }
}