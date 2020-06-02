using UnityEngine;
using UnityEngine.Audio;

class AdsController : MonoBehaviour, IInitializationSystem
{
    private IShowAds _showAds;

    public void Initialization()
    {
        _showAds = IocContainer.Instance.UnitiShowAds;
        IocContainer.Instance.GameStatusSystem.OnGameOver += LongAdsStart;
        IocContainer.Instance.GameLevel.OnLevelComplit += ShortAdsStart;
    }
    
    private void LongAdsStart()
    {
        _showAds.ShowLongAds();
        IocContainer.Instance.LiveContrller.LiveAdd(3);
    }

    private void ShortAdsStart()
    {
        _showAds.SkipAds += PlayGame;
        IocContainer.Instance.GameStatusSystem.Pause();
        _showAds.ShowShortAds();
    }

    private void PlayGame()
    {
        IocContainer.Instance.GameStatusSystem.Play();
    }
}