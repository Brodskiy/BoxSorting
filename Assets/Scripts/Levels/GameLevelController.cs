using UnityEngine;

class GameLevelController:MonoBehaviour//todo
{
    [SerializeField] private LevelsContainer _levelsContainer;
    [SerializeField] private SaveLoadLevel _saveLoadLevel;

    public LevelModelBase UnlockLevel { get; private set; }
    public LevelModelBase SelectedLevel { get; private set; }

    private void Awake()
    {
        UnlockLevel = _levelsContainer.Levels[_saveLoadLevel.SavedLevelData.ActiveLevels];
        SelectedLevel = _levelsContainer.Levels[_saveLoadLevel.SavedLevelData.SelectedLevel];
    }
}