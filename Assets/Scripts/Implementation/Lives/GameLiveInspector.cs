using System;
using UnityEngine;

class GameLiveInspector : MonoBehaviour
{
    [SerializeField] private GameStatusController _gameStatus;
    [SerializeField] private DisplayInfo _textDisplayLive;

    public event Action LostLive;

    private ILiveLoader _livInfo;
    private int _maxLives = 3;

    private void Start()
    {
        _livInfo = IocContainer.Instance.LiveLoader;
        _textDisplayLive.DisplayText(_livInfo.LiveDataInfo.Lives, "Lives");
    }
    public void LiveIsLost(int lostLives)
    {
        _livInfo.LiveDataInfo.Lives -= lostLives;
        _textDisplayLive.DisplayText(_livInfo.LiveDataInfo.Lives, "Lives");
        LostLive?.Invoke();
        _livInfo.SaveData();

        GameOverControll();
    }

    public void LiveAdd(int addLives)
    {
        if (_livInfo.LiveDataInfo.Lives + addLives <= _maxLives)
        {
            _livInfo.LiveDataInfo.Lives += addLives;
            _textDisplayLive.DisplayText(_livInfo.LiveDataInfo.Lives, "Lives");
            _livInfo.SaveData();
        }
    }

    private void GameOverControll()
    {
        if (_livInfo.LiveDataInfo.Lives <= 0)
        {
            IocContainer.Instance.GameStatusSystem.GameOver();
        }
    }    
}