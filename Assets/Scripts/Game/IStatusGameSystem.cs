using System;

public interface IStatusGameSystem
{
    event Action GameOver;
    event Action GameStart;
    void OnPause();
    void OnPlay();
}