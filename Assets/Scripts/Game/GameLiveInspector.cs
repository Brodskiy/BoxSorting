using System;
using UnityEngine;

class GameLiveInspector : MonoBehaviour
{
    [SerializeField] private GameStatusView _gameStatus;
    [SerializeField] private DisplayInfo _textDisplayLive;

    public int Lives { get; private set; } = 3;

    public event Action GameOver;
    public event Action LiveLost;

    private void Start()
    {
        _textDisplayLive.DisplayText(Lives, "Lives");
    }

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
        _textDisplayLive.DisplayText(Lives, "Lives");
        LiveLost?.Invoke();
        GameOverControll();
    }
}