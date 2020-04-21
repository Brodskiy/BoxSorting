﻿using System;
using UnityEngine;

class GameLiveInspector : MonoBehaviour
{
    [SerializeField] private GameStatusView _gameStatus;

    public int Lives { get; private set; } = 3;

    public event Action GameOver;

    private void GameOverControll()
    {
        if (Lives <= 0)
        {
            GameOver?.Invoke();
            _gameStatus.OnGameOver();
        }
    }

    public void LiveIsLost()
    {
        Lives--;
        GameOverControll();
    }
}