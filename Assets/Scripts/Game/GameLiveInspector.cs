using System;
using UnityEngine;

class GameLiveInspector : MonoBehaviour
{
    [SerializeField] private GameStatusController _gameStatus;
    [SerializeField] private DisplayInfo _textDisplayLive;

    public int Lives { get; private set; } = 3;

    public event Action LiveLost;

    private void Start()
    {
        _textDisplayLive.DisplayText(Lives, "Lives");
    }

    private void GameOverControll()
    {
        if (Lives <= 0)
        {
            IocContainer.Instance.GameStatusSystem.GameOver();
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