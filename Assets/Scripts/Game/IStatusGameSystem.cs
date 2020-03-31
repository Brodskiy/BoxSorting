
    using System;

    public interface IStatusGameSystem
    {
        event Action GameOver;
        event Action Start;
        void OnPause();
        void OnPlay();
    }
