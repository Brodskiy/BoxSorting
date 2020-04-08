using System;
using UnityEngine;

public class GameLevelInspector : MonoBehaviour, IContainerSystem
{
    [SerializeField] private LevelsContainer _levelContainer;

    private ILevelContain AllLevels => _levelContainer;

    private float _levelTime;
    private float _timer;
    private int _activeLevel;

    public event Action<LevelModel> LevelUp;

    public LevelModel CurrentLevel { get; private set; }

    public void Init()
    {
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
        }
    }

    private void SetCurrentLevel()
    {
        CurrentLevel = AllLevels.Levels[_activeLevel];
        _levelTime = CurrentLevel.LevelTimer;
    }    
}