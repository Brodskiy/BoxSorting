using System;
using UnityEngine;

enum ETimeScale
{
    TimeStop,
    TimeGo
}

public class GameStatusController : IStatusGameSystem
{
    public event Action OnGameOver;
    public event Action OnGameStart;

    public bool IsCanSpawn { get; set; } = true;

    public void GameOver()
    {
        Pause();
        OnGameOver?.Invoke();
    }

    public void StartGame()
    {
        Play();
        OnGameStart?.Invoke();
    }

    public void Pause()
    {
        SetTimeScale(ETimeScale.TimeStop);
        SetOpportunitySpawn(false);
    }

    public void Play()
    {
        SetTimeScale(ETimeScale.TimeGo);
        SetOpportunitySpawn(true);
    }

    private void SetOpportunitySpawn(bool canSpawn)
    {
        IsCanSpawn = canSpawn;
    }

    private void SetTimeScale(ETimeScale timeScale)
    {
        switch (timeScale)
        {
            case ETimeScale.TimeStop:
                Time.timeScale = 0;
                break;
            case ETimeScale.TimeGo:
                Time.timeScale = 1;
                break;
        }
    }
}