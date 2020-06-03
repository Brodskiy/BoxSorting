using System;

public interface IShowAds : IInitializationSystem
{
    event Action FinishAds;
    void ShowShortAds();
    void ShowLongAds();
}