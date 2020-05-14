using UnityEngine;

public class SpawnController
{
    [SerializeField] private BaseGameElement _floor;
    [SerializeField] private BaseGameElement _character;

    public SpawnSystem Spawn;

    public void Init()
    {
        Spawn = new SpawnSystem();

        var floor = Spawn.SpawnObject<FloorView>(_floor);
        floor.Initialization();

        var character = Spawn.SpawnObject<CharacterView>(_character);
    }
}