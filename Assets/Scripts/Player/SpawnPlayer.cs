using UnityEngine;

public class SpawnPlayer : BaseSpawnObject, IContainerSystem
{
    [SerializeField] private PlayerMoves _playerPrefab;

    public void Init() // todo: refactoring
    {
        SpawnObject(_playerPrefab.gameObject);
    }
    
    public override void SpawnObject(GameObject go)
    {
        Instantiate(go);
    }
}