using System.Collections.Generic;
using UnityEngine;
class LevelButtonSpawn : MonoBehaviour
{
    [SerializeField] private LevelButtonBase _buttonPrefab;
    [SerializeField] private LevelsContainer _levelsContainer;
    [SerializeField] private SaveLoadLevel _saveLoadLevel;
    [SerializeField] private Transform _parentForLevelButton;

    private int _activeLevel;

    public List<LevelButtonBase> LevelButtons;

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
            var button = Instantiate(_buttonPrefab, _parentForLevelButton);
            button.CountNumber = i;

            if (i <= _activeLevel)
            {
                button.IsActive = true;
            }

            button.GetComponent<LevelButtonView>().ShowInfo();
            LevelButtons.Add(button);
        }
    }
}