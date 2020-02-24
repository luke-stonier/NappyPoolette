using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private BannerView bannerView;

    public void Start()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-4698588719115567~7943883443";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-4698588719115567~6906133946";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

     private void RequestBanner()
     {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-4698588719115567/8613983197";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-4698588719115567/5593052273";
        #else
            string adUnitId = "unexpected_platform";
        #endif

         // Create a 320x50 banner at the top of the screen.
         bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
         AdRequest request = new AdRequest.Builder().Build();
         // Load the banner with the request.
         bannerView.LoadAd(request);
         bannerView.Show();
    }
}
