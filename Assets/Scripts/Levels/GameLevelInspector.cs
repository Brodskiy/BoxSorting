using System;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelInspector : MonoBehaviour, IInitializationSystem
{
    [SerializeField] private LevelsContainer _levelContainer;
    [SerializeField] private SaveLoadLevel _loadData;
    [SerializeField] private SceneChangeSystem _sceneChangeSystem;
    [SerializeField] private SpawnBox _spawnBox;
    [SerializeField] private GameObject _panelLevelPassed;
    [SerializeField] private DisplayInfo _displayTime;

    private ILevelContain AllLevels => _levelContainer;

    private float _levelTime;
    private float _timer;
    public int _activeLevel;

    public event Action<LevelModelBase> LevelPassed;

    public LevelModelBase CurrentLevel { get; private set; }

    public void Initialization()
    {
        _loadData.Load();
        _activeLevel = _loadData.SavedLevelData.SelectedLevel;
        SetCurrentLevel();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        TimeControl();
    }

    private void TimeControl()
    {
        _displayTime.DisplayText(_levelTime - _timer, "Time");

        if (_timer >= _levelTime)
        {
            StartNextLevel();
        }
    }

    private void StartNextLevel()
    {
        _activeLevel++;
        _timer = 0;
        SetCurrentLevel();
        LevelPassed?.Invoke(CurrentLevel);
        BoxAndSpawnStop();

        SetNewLevelData();
        RunNewLevel();
    }

    private void SetNewLevelData()
    {
        _loadData.SavedLevelData.SelectedLevel = _activeLevel;

        if (_loadData.SavedLevelData.ActiveLevels < _activeLevel)
        {
            _loadData.SavedLevelData.ActiveLevels = _activeLevel;
        }

        _loadData.SaveData();
    }

    private void RunNewLevel()
    {      
        _panelLevelPassed.SetActive(true);
        _sceneChangeSystem.RunGameScene();
    }

    private void BoxAndSpawnStop()
    {
        IocContainer.Instance.GameStatusSystem.IsCanSpawn = false;

        foreach (var box in _spawnBox._listBoxes)
        {
            box._moveBox._speed = 0;
        }
    }

    private void SetCurrentLevel()
    {
        CurrentLevel = AllLevels.Levels[_activeLevel];
        CurrentLevel.IsOpen = true;
        _levelTime = CurrentLevel.LevelTimer;
    }    
}