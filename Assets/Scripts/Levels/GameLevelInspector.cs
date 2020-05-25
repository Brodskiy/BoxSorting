using System;
using UnityEngine;

public class GameLevelInspector : MonoBehaviour, ILevelSystem
{
    [SerializeField] private LevelsContainer _levelContainer;
    [SerializeField] private SaveLoadLevel _loadData;
    [SerializeField] private SceneChangeSystem _sceneChangeSystem;
    [SerializeField] private GameObject _panelLevelPassed;
    [SerializeField] private DisplayInfo _displayTime;

    public event Action<LevelModelBase> OnLevelComplit;

    public LevelModelBase CurrentLevel { get; private set; }
    public int ActiveLevel { get; private set; }

    private ILevelContain AllLevels => _levelContainer;
    private IStatusGameSystem _gameStatusController; 
    private float _levelTime;
    private float _timer;
    

    public void Initialization()
    {
        _loadData.Load();
        ActiveLevel = _loadData.SavedLevelData.SelectedLevel;
        SetCurrentLevel();
    }

    private void Update()
    {       
        TimeController();
    }

    private void TimeController()
    {
        if (IocContainer.Instance.GameStatusSystem.IsCanSpawn)
        {
            _timer += Time.deltaTime;
        }
       
        _displayTime.DisplayText(_levelTime - _timer, "Time");        

        if (_timer >= _levelTime)
        {
            StartNextLevel();
        }
    }

    private void StartNextLevel()
    {
        _gameStatusController = IocContainer.Instance.GameStatusSystem;
        _gameStatusController.IsCanSpawn = false;
        _gameStatusController.IsCanMove = false;

        ActiveLevel++;
        _timer = 0;
        SetCurrentLevel();
        OnLevelComplit?.Invoke(CurrentLevel);

        SetNewLevelData();
        RunNewLevel();
    }

    private void SetNewLevelData()
    {
        _loadData.SavedLevelData.SelectedLevel = ActiveLevel;

        if (_loadData.SavedLevelData.ActiveLevels < ActiveLevel)
        {
            _loadData.SavedLevelData.ActiveLevels = ActiveLevel;
        }

        _loadData.SaveData();
    }

    private void RunNewLevel()
    {      
        _panelLevelPassed.SetActive(true);
        _sceneChangeSystem.RunGameScene();
    }    

    private void SetCurrentLevel()
    {
        CurrentLevel = AllLevels.Levels[ActiveLevel];
        CurrentLevel.IsOpen = true;
        _levelTime = CurrentLevel.LevelTimer;
    }    
}