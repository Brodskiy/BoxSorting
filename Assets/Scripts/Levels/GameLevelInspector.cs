using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelInspector : MonoBehaviour
{
    private float _levelTime;
    private float _timer;
    private int _activeLevel;

    public event Action<LevelModel> LevelUp;
    public LevelModel CurrentLevel { get; private set; }

    public List<LevelModel> GameLevels = new List<LevelModel>
    {
        new LevelModel(5, 30, 2, 4),
        new LevelModel(4.5f, 30, 2, 4),
        new LevelModel(4f, 30, 2, 4),
        new LevelModel(3.5f, 30, 2, 4),
        new LevelModel(3f, 30, 2, 4),
        new LevelModel(4.5f, 30, 3, 4),
        new LevelModel(4f, 30, 3, 4),
        new LevelModel(3.5f, 30, 3, 4),
        new LevelModel(3f, 30, 3, 4),
        new LevelModel(4.5f, 30, 3, 5),
        new LevelModel(4f, 30, 3, 5),
        new LevelModel(3.5f, 30, 3, 5),
        new LevelModel(3f, 30, 3, 5),
        new LevelModel(4f, 30, 4, 5),
        new LevelModel(3.5f, 30, 4, 5)
    };

    private void Start()
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
        CurrentLevel = GameLevels[_activeLevel];
        _levelTime = CurrentLevel.LevelTimer;
    }
}