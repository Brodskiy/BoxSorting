using System;

public interface IStatusGameSystem
{
    event Action OnGameOver;
    event Action OnGameStart;

    bool IsCanSpawn { get; set; }
    bool IsCanMove { get; set; }

    void GameOver();
    void Pause();
    void Play();
}