using System.Collections.Generic;
using UnityEngine;
class LevelButtonSpawn : MonoBehaviour
{
    [SerializeField] private LevelButtonControler _buttonController;
    [SerializeField] private LevelsContainer _levelsContainer;
    [SerializeField] private SaveLoadLevel _saveLoadLevel;
    [SerializeField] private Transform _parentForLevelButton;

    private int _activeLevel;

    public List<LevelButtonControler> LevelButtons;

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
            LevelButtonControler button = Instantiate(_buttonController, _parentForLevelButton);
            button.SetCountNumberLevelButton(i);

            if (i <= _activeLevel)
            {
                button.SetIsActiveLevelButton(true);
            }

            button.GetComponent<LevelButtonView>().ShowInfo();
            LevelButtons.Add(button);
        }
    }
}