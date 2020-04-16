using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelInspector : MonoBehaviour, IContainerSystem
{
    [SerializeField] private LevelsContainer _levelContainer;
    [SerializeField] private SaveLoadLevel _loadData;

    private ILevelContain AllLevels => _levelContainer;

    private float _levelTime;
    private float _timer;
    public int _activeLevel;//TODO

    public event Action<LevelModelBase> LevelUp;

    public LevelModelBase CurrentLevel { get; private set; }

    public void Init()
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
        if (_timer >= _levelTime)
        {
            _activeLevel++;
            _timer = 0;
            SetCurrentLevel();            
            LevelUp?.Invoke(CurrentLevel);
            SceneManager.LoadScene("LevelScene");
        }
    }

    private void SetCurrentLevel()
    {
        CurrentLevel = AllLevels.Levels[_activeLevel];
        CurrentLevel.IsOpen = true;
        _levelTime = CurrentLevel.LevelTimer;
    }    
}