using UnityEngine;

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
        _showAds.FinishAds += Finish;
        IocContainer.Instance.LiveContrller.LiveAdd(3);
    }   

    private void ShortAdsStart()
    {        
        _showAds.ShowShortAds();
    }
    private void Finish()
    {
        IocContainer.Instance.GameStatusSystem.Pause();
    }
}