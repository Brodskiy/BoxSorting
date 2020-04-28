using System;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelInspector : MonoBehaviour, IContainerSystem
{
    [SerializeField] private LevelsContainer _levelContainer;
    [SerializeField] private SaveLoadLevel _loadData;
    [SerializeField] private SceneChangeSystem _sceneChangeSystem;
    [SerializeField] private Text _textLevelPassed;

    private ILevelContain AllLevels => _levelContainer;

    private float _levelTime;
    private float _timer;
    public int _activeLevel;

    public event Action<LevelModelBase> LevelPassed;

    public LevelModelBase CurrentLevel { get; private set; }

    public void Init()
    {
        _loadData.Load();
        _activeLevel = _loadData.SavedLevelData.ActiveLevels;
        SetCurrentLevel();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        TimeControl();
    }

    private void TimeControl()
    {
        if (_timer >= _levelTime)
        {
            _activeLevel++;
            _timer = 0;
            SetCurrentLevel();            
            LevelPassed?.Invoke(CurrentLevel);

            if(_loadData.SavedLevelData.ActiveLevels < _activeLevel)
            {
                _loadData.SavedLevelData.ActiveLevels = _activeLevel;
            }
           
            _loadData.SaveData();
            _textLevelPassed.enabled = true;
            _sceneChangeSystem.RunGameScene();
        }
    }

    private void SetCurrentLevel()
    {
        CurrentLevel = AllLevels.Levels[_activeLevel];
        CurrentLevel.IsOpen = true;
        _levelTime = CurrentLevel.LevelTimer;
    }    
}