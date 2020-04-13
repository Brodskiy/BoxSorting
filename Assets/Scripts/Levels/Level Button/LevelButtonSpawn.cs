using UnityEngine;
class LevelButtonSpawn : MonoBehaviour
{
    [SerializeField] private LevelButtonBase _buttonPrefab;
    [SerializeField] private LevelsContainer _levelsContainer;
    [SerializeField] private SaveLoadLevel _saveLoadLevel;

    private int _activeLevel;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        _saveLoadLevel.Load();
        _activeLevel = _saveLoadLevel._saveLevelData.ActiveLevels;

        for (int i = 1; i <= _levelsContainer.Levels.Count; i++)
        {
            var levelButton = Instantiate(_buttonPrefab);
            levelButton.transform.position = transform.parent.position;
            _buttonPrefab.CountNumber = i;

            if (i <= _activeLevel)
            {
                _buttonPrefab.IsActive = true;
            }
        }
    }
}