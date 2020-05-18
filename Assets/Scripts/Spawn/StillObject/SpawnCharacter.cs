using UnityEngine;
class SpawnCharacter : SpawnStillObject
{
    [SerializeField] private BaseGameElement _characterPrefab;
    public override void Init()
    {
        SpawnObject<CharacterView>(_characterPrefab);
    }
}