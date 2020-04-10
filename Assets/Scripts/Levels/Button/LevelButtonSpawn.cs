using UnityEngine;
class LevelButtonSpawn : MonoBehaviour
{
    [SerializeField] private LevelButtonBase _buttonPrefab;
    [SerializeField] private LevelsContainer _levelsContainer;
    [SerializeField] private SaveLoadLevel _saveLoadLevel;

    private int _activeLevel;

    public void Spawn()
    {
        _saveLoadLevel.Load();
        _activeLevel = _saveLoadLevel._saveLevelData.ActiveLevels;

        for (int i = 1; i <= _levelsContainer.Levels.Count; i++)
        {
            Instantiate(_buttonPrefab);
            _buttonPrefab.CountNumber = i;

            if (i <= _activeLevel)
            {
                _buttonPrefab.IsActive = true;
            }
        }
    }
}