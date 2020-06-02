using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

class UnityAdsView : MonoBehaviour, IShowAds
{
#if UNITY_IOS
    private readonly string _gameId = "3630266";
#elif UNITY_ANDROID
    private readonly string _gameId = "3630267";
#endif
    public event Action SkipAds;

    private readonly string _placementVideo = "video";
    private readonly string _placementRewardVideo = "rewardedVideo";  

    public void Initialization()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, true);
        }
    }

    public void ShowShortAds()
    {        
        StartCoroutine(ShowAdsCoroutine(_placementVideo));
    }

    public void ShowLongAds()
    {
        StartCoroutine(ShowAdsCoroutine(_placementRewardVideo));
    }

    private IEnumerator ShowAdsCoroutine(string placement)
    {
        while (!Advertisement.IsReady(placement))
        {
            yield return null;
        }
        Advertisement.Show(placement, new ShowOptions
        {
            resultCallback = result =>
            {
                if (result == ShowResult.Skipped)
                {
                    SkipAds?.Invoke();
                }
            }
        });
    }    
}