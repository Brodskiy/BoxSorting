using System;
using UnityEngine;

class GameLiveInspector : MonoBehaviour
{
    [SerializeField] private GameStatusController _gameStatus;
    [SerializeField] private DisplayInfo _textDisplayLive;

    public static int Lives { get; private set; }

    public event Action LostLive;

    private readonly int _maxLives = 3;
    private void Start()
    {
        Lives = _maxLives;
        _textDisplayLive.DisplayText(Lives, "Lives");
    }
    public void LiveIsLost(int lostLives)
    {
        Lives -= lostLives;
        _textDisplayLive.DisplayText(Lives, "Lives");
        LostLive?.Invoke();
        GameOverControll();
    }

    public void LiveAdd(int addLives)
    {
        if (Lives + addLives <= _maxLives)
        {
            Lives += addLives;
            _textDisplayLive.DisplayText(Lives, "Lives");
        }
    }

    private void GameOverControll()
    {
        if (Lives <= 0)
        {
            IocContainer.Instance.GameStatusSystem.GameOver();
        }
    }    
}