using System;
using UnityEngine.Advertisements;

public interface IShowAds : IInitializationSystem
{
    event Action SkipAds;
    void ShowShortAds();
    void ShowLongAds();
}