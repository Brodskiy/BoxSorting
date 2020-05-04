using System;
using UnityEngine;

enum ETimeScale
{
    TimeStop,
    TimeGo
}

public class GameStatusController : MonoBehaviour, IStatusGameSystem
{    
    public event Action OnGameOver;
    public event Action OnGameStart;

    public bool IsCanSpawn { get; set; } = true;

    public void GameOver()
    {
        OnPause();
        OnGameOver?.Invoke();
    }

    public void StartGame()
    {
        OnPlay();
        OnGameStart?.Invoke();
    }

    public void OnPause()
    {
        SetTimeScale(ETimeScale.TimeStop);
        SetOpportunitySpawn(false);
    }

    public void OnPlay()
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