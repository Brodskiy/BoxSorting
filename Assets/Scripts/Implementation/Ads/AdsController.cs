using UnityEngine;

class AdsController : MonoBehaviour, IInitializationSystem
{
    private IShowAds _showAds;
    private ILiveLoader _liveLoader;

    public void Initialization()
    {
        _showAds = IocContainer.Instance.UnitiShowAds;
        IocContainer.Instance.GameStatusSystem.OnGameOver += LongAdsStart;
        IocContainer.Instance.GameLevel.OnLevelComplit += ShortAdsStart;
    }
    
    private void LongAdsStart()
    {
        _showAds.ShowLongAds();
        _liveLoader = IocContainer.Instance.LiveLoader;
        _liveLoader.LiveDataInfo.Lives = 3;
        _liveLoader.SaveData();

    }

    private void ShortAdsStart()
    {
        _showAds.ShowShortAds();
    }
}