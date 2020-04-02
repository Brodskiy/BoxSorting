using System;
using UnityEngine;

public class TransitionLevel : MonoBehaviour
{
    private const float ZERO = 0;

    private float _timeLevel = 10;
    private float _timerLevel;

    public event Action LevelCompleted;

    private void Update()
    {
        Timer();
        CheckTimeLevel();
    }

    private void Timer()
    {
        _timerLevel += Time.deltaTime;
    }

    private void CheckTimeLevel()
    {
        if (_timeLevel <= _timerLevel)
        {
            LevelCompleted?.Invoke();
            _timerLevel = ZERO;
        }
    }
}