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

    public event Action FinishAds;

    private readonly string _placementVideo = "video";
    private readonly string _placementRewardVideo = "rewardedVideo";
    private readonly bool _isTestAds = false;
    private readonly float _waitTimeSeconds = 0.7f;

    public void Initialization()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _isTestAds);            
        }
    }

    public void ShowShortAds()
    {
        StartCoroutine(AdsStartForSeconds(_placementVideo, _waitTimeSeconds));
    }

    public void ShowLongAds()
    {
        StartCoroutine(AdsStartForSeconds(_placementRewardVideo, _waitTimeSeconds));
    }

    private IEnumerator AdsStartForSeconds(string placement, float waitTimeSeconds)
    {
        yield return new WaitForSeconds(waitTimeSeconds);
        Advertisement.Load(placement);
        StartCoroutine(ShowAdsCoroutine(placement));
    }
     
    private IEnumerator ShowAdsCoroutine(string placement)
    {
        IocContainer.Instance.GameStatusSystem.Pause();

        if (Advertisement.IsReady(placement) == false)
        {
            IocContainer.Instance.GameStatusSystem.Play();
            FinishAds?.Invoke();

            Initialization();
            Advertisement.Load(placement);

            yield return null;
        }

        Advertisement.Show(placement, new ShowOptions
        {
            resultCallback = result =>
            {
                IocContainer.Instance.GameStatusSystem.Play();

                if (result == ShowResult.Finished)
                {
                    FinishAds?.Invoke();
                }
            }
        });
    } 
}