using UnityEngine;
public class SpawnFloorSystem : SpawnStillObject
{
    [SerializeField] private BaseGameElement _floorPrefab;

    public override void Init()
    {
        SpawnObject<FloorView>(_floorPrefab);
    }
}