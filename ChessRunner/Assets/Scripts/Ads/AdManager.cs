using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{

    private string app_id = "ca-app-pub-9506211863408963~4225086861";

    private BannerView _bannerAd;

    private RewardBasedVideoAd _rewardAd;

    [SerializeField]
    private GameObject GameOverPopUpGO;

    // Start is called before the first frame update
    void Start()
    {
        // When publish
        MobileAds.Initialize(app_id);
        
        #if UNITY_EDITOR
            print("Unity Version");

        #elif PLATFORM_ANDROID
            RequestBanner();
            print("Android Version");
        #endif

        RewardSubscriptions();
    }

    void RequestBanner()
    {
        string bannerID = "ca-app-pub-9506211863408963/7069029599";
        _bannerAd = new BannerView(bannerID, AdSize.SmartBanner, AdPosition.Bottom);

        //For real app
        AdRequest adRequest = new AdRequest.Builder().Build();
        DisplayBanner();
        
        //For test
       // AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        _bannerAd.LoadAd(adRequest);

        //Show banner for test
        
    }

    public void DisplayBanner()
    {
        _bannerAd.Show();
    }

    public void RequestRewardVideo()
    {
        string rewardVideoID = "ca-app-pub-9506211863408963/4197005971";
        _rewardAd = RewardBasedVideoAd.Instance;

        AdRequest request = new AdRequest.Builder().Build();
       
        // Load the rewarded video ad with the request.
        _rewardAd.LoadAd(request, rewardVideoID);

        //ReviveHorse();
    }

    public void LoadRewardVideoAd()
    {
       
    }

    public void RewardSubscriptions()
    {
        // Called when an ad request has successfully loaded.
       // _rewardAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        //_rewardAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        
        // Called when the user should be rewarded for watching a video.
       // _rewardAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        
    }

    //Handle Events

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //Ad is Loaded, show it
        DisplayBanner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //Ad failed to load, load it again
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //If the player touches the ad, we can do something maybe
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //It's more for interstitical
    }

    void HandleBannerADEvents()
    {
        // Called when an ad request has successfully loaded.
        _bannerAd.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        _bannerAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        _bannerAd.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        _bannerAd.OnAdClosed += HandleOnAdClosed;
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
       // Turn Button On

    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
       // RequestRewardVideo();
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;

        ReviveHorse();
       
    }

    public void ReviveHorse()
    {
        Horse.horse.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        Horse.playerIsDead = false;

        GameOverPopUpGO.SetActive(false);
    }


}
