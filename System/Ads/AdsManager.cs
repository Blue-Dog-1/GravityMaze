using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

namespace Tysseek.Ads
{
    [AddComponentMenu("Project/AdsManager")]
    public class AdsManager : MonoBehaviour
    {

        private InterstitialAd interstitial;

        private BannerView bannerView;



        private void Awake()
        {
        }

        private void Start()
        {
            List<String> deviceIds = new List<String>() { AdRequest.TestDeviceSimulator };

#if UNITY_ANDROID

            deviceIds.Add("9dc88a82bc0b48db8a6e45dbe96f159a");
#else
            string adUnitId = "unexpected_platform";
#endif
            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(initStatus => { });
            RequestBanner();
            RequestInterstitial();

            StartCoroutine(Tysseek.Delay(2, ShowIntegrationAd ));

        }

        private void RequestBanner()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            

            // Load the banner with the request.
            bannerView.LoadAd(request);
        }


        private void RequestInterstitial()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }


        public void ShowIntegrationAd()
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
        }

        private void OnDestroy()
        {
            DestroyIntegrationAd();
        }

        private void HandlerOnAdClosed(object sender, EventArgs e)
        {
            interstitial.OnAdLoaded -= HandlerOnAdLoaded;
            interstitial.OnAdOpening -= HandlerOnAdOpening;
            interstitial.OnAdClosed -= HandlerOnAdClosed;

            RequestInterstitial();
            //Events.Restart?.Invoke(); ///////////////////////////

        }

        private void HandlerOnAdOpening(object sender, EventArgs e)
        {
        }

        private void HandlerOnAdLoaded(object sender, EventArgs e)
        {
        }

        public void DestroyIntegrationAd()
        {
            interstitial?.Destroy();
            bannerView?.Destroy();
        }
    }
}