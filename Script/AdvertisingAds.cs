using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public class AdvertisingAds : MonoBehaviour
{
    public bool isTesting;
#if UNITY_ANDROID || UNITY_IOS
    const string VideoPlacementId = "video";
    const string RewardedPlacementId = "rewardedVideo";
    void Start()
    {

        // initialize adverts
        if (InternetCheck.CheckConectInternet())
        {
         StartCoroutine(AdsInitialization());
        }
         // end initialize 
    }
    IEnumerator AdsInitialization()
    {
        yield return new WaitForSeconds(5f);
        if (Advertisement.isSupported) {
             Advertisement.Initialize ("3551764", isTesting);
             Debug.Log("Platform supported");
             yield return null;
        } 
         else {
             Debug.Log("Platform not supported");
         }
    }
    public static void StaticShow()
    {
        if (Advertisement.IsReady(VideoPlacementId))
        {
            Advertisement.Show(VideoPlacementId);
        }
    }
    public void adshow(bool isSkip)
    {
        
        if (Advertisement.IsReady(VideoPlacementId) && isSkip)
        {
            Advertisement.Show(VideoPlacementId);
        }
        if (Advertisement.IsReady(RewardedPlacementId) && !isSkip)
        {
            Advertisement.Show(RewardedPlacementId);
        }
    
    }
#endif
}
