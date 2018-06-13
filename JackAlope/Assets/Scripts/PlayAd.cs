using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using Heyzap;
using AdColony;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAd : MonoBehaviour
{

    int rand;
    public Text Counter;
    public GameObject go;
    public string[] zoneIDs = new string[] { "vz724467f142854a3d94", "vzb30111684a9643cfa7" };
    public string AppID  = "app6a252394f52f458a9c";
    AdColony.InterstitialAd _ad = null;
    public GameObject oldplayer, hud, healthbar, controls, gameoverscreen, enemies;

    public void WatchADs()
    {
        rand = Random.Range(0, 3);

#if UNITY_ANDROID
        if (rand == 0)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Initialize("2586763");
             //   Debug.Log(Advertisement.gameId);
                Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
            }
        }

        if (rand == 1)
        {
            //APLOVIN

            AppLovin.SetRewardedVideoUsername("JackAlope_AppLovin");


            if (AppLovin.IsIncentInterstitialReady())
            {
                AppLovin.ShowRewardedInterstitialForZoneId("4bcd90e276831a9d");
                //AppLovin.ShowRewardedInterstitial();
                onAppLovinEventReceived("HIDDENREWARDED");
            }
            else
            {
                // No rewarded ad is available.  Perform failover logic...
                if (AppLovin.HasPreloadedInterstitial())
                {
                    // An ad is currently available, so show the interstitial.
                    AppLovin.ShowInterstitial();
                    onAppLovinEventReceived("HIDDENINTER");
                }
                else
                {

                    // No ad is available.  Perform failover logic...
                    AppLovin.LoadRewardedInterstitial();
                    ContinuePlaying();
                    /*Debug.Log("Player gain 5 GEMS");
                    go = GameObject.FindGameObjectWithTag("GameOver");
                    go.GetComponent<GameOverScrn>().RestartLevel();*/

                    //  gameoverfunctions.GetComponent<GameOverScrn>().RestartLevel();
                }
            }
            
        }


        //HEYZAP

        if (rand == 5)
        {
            HZIncentivizedAd.AdDisplayListener listener = delegate (string adState, string adTag)
            {
                if (adState.Equals("available"))
                {
                    Debug.Log("Available");
                    HZIncentivizedAd.Show();
                    // Sent when an ad has been loaded and is ready to be displayed,
                    //   either because we autofetched an ad or because you called
                    //   `Fetch`.
                }
                if (adState.Equals("fetch_failed"))
                {
                    Debug.Log("Failed Fetch Incentive");
                    // Sent when an ad has failed to load.
                    // This is sent with when we try to autofetch an ad and fail, and also
                    //    as a response to calls you make to `Fetch` that fail.
                    // Some of the possible reasons for fetch failures:
                    //    - Incentivized ad rate limiting (see your app's Publisher
                    //      Settings dashboard)
                    //    - None of the available ad networks had any fill
                    //    - Network connectivity
                    //    - The given ad tag is disabled (see your app's Publisher
                    //      Settings dashboard)
                    //    - One or more of the segments the user falls into are
                    //      preventing an ad from being fetched (see your
                    //      Segmentation Settings dashboard)
                    HZIncentivizedAd.Fetch();
                }
                if (adState.Equals("incentivized_result_complete"))
                {
                    HZIncentivizedAd.Fetch();
                    Debug.Log("Player gain 5 GEMS");
                    go = GameObject.FindGameObjectWithTag("GameOver");
                    go.GetComponent<GameOverScrn>().RestartLevel();
                    // The user has watched the entire video and should be given a reward.
                }
                if (adState.Equals("incentivized_result_incomplete"))
                {
                    HZIncentivizedAd.Fetch();
                    // The user did not watch the entire video and should not be given a   reward.
                }
                if (adState.Equals("audio_starting"))
                {
                    // The ad about to be shown will need audio.
                    // Mute any background music.
                }
                if (adState.Equals("audio_finished"))
                {
                    // The ad being shown no longer needs audio.
                    // Any background music can be resumed.
                }
                if (adState.Equals("show"))
                {

                    // Sent when an ad has been displayed.
                    // This is a good place to pause your app, if applicable.
                }
                if (adState.Equals("hide"))
                {
                    HZIncentivizedAd.Fetch();
                    Debug.Log("Player gain 5 GEMS");
                    go = GameObject.FindGameObjectWithTag("GameOver");
                    go.GetComponent<GameOverScrn>().RestartLevel();
                    // Sent when an ad has been removed from view.
                    // This is a good place to unpause your app, if applicable.
                }
                if (adState.Equals("click"))
                {
                    // Sent when an ad has been clicked by the user.
                }
            };
            HZIncentivizedAd.SetDisplayListener(listener);
            if (HZIncentivizedAd.IsAvailable())
            {
                HZIncentivizedAd.Show();
                // StartCoroutine(restarWait());
                HZIncentivizedAd.Fetch();
            }
            else
            {
                // WatchADs();
                rand = 3;
            }
        }
        if (rand == 2)
        {
            // [AdColony]
            ConfigureAds();
            RegisterForAdsCallbacks();
            RequestAdReward();
            PlayAdv();
        }
          
#endif

    }
    
    IEnumerator restarWait()
    {
        yield return new WaitForSeconds(1f);
        ContinuePlaying();
        /*Debug.Log("Player gain 5 GEMS");
        go = GameObject.FindGameObjectWithTag("GameOver");
        go.GetComponent<GameOverScrn>().RestartLevel();*/
    }
    void onAppLovinEventReceived(string ev)
    {
        // The format would be "REWARDAPPROVEDINFO|AMOUNT|CURRENCY"
        if (ev.Contains("LOADEDREWARDED"))
        {
            // A rewarded video was successfully loaded.

        }
        else if (ev.Contains("LOADREWARDEDFAILED"))
        {
            // A rewarded video failed to load.
        }
        else if (ev.Contains("HIDDENREWARDED"))
        {
            // A rewarded video has been closed.  Preload the next rewarded video.
            AppLovin.LoadRewardedInterstitial("c90f0b1ccbd02983");
            ContinuePlaying();

            /*Debug.Log("Player gain 5 GEMS");
            go = GameObject.FindGameObjectWithTag("GameOver");
            go.GetComponent<GameOverScrn>().RestartLevel();*/
        }

        if (ev.Contains("DISPLAYEDINTER"))
        {
            // An ad was shown.  Pause the game.
        }
        else if (ev.Contains("HIDDENINTER"))
        {
            // Ad ad was closed.  Resume the game.
            // If you're using PreloadInterstitial/HasPreloadedInterstitial, make a preload call here.
            AppLovin.PreloadInterstitial();

            this.oldplayer = GameObject.FindGameObjectWithTag("Player");
            ContinuePlaying();

            /*Debug.Log("Player gain 5 GEMS");
            go = GameObject.FindGameObjectWithTag("GameOver");
            go.GetComponent<GameOverScrn>().RestartLevel();*/
        }
        else if (ev.Contains("LOADEDINTER"))
        {
            // An interstitial ad was successfully loaded.

        }
        else if (string.Equals(ev, "LOADINTERFAILED"))
        {
            // An interstitial ad failed to load.
        }
    }
    

     private void HandleAdResult(ShowResult result)
     {
         switch (result)
         {
             case ShowResult.Finished:
                ContinuePlaying();

                break;
             case ShowResult.Skipped:
                 Debug.Log("The player skiped");
                 break;
             case ShowResult.Failed:
                 Debug.Log("NOT INTERNET MAYBE");
                 break;
         }
     }


    public string taginput = "AmericanPixelSteetBattle HeyZap";
    private string adTag()
    {
        string tag = this.taginput;
        if (tag == null || tag.Trim().Length == 0)
        {
            return "default";
        }
        else
        {
            return tag;
        }
    }


    void ConfigureAds()
     {

         // AppOptions are optional
         AdColony.AppOptions appOptions = new AdColony.AppOptions();

         appOptions.UserId = "JackAlope";
         appOptions.AdOrientation = AdColony.AdOrientationType.AdColonyOrientationAll;
         if (Application.platform == RuntimePlatform.Android ||
         Application.platform == RuntimePlatform.IPhonePlayer )
         {
             Ads.Configure(this.AppID, appOptions, this.zoneIDs);
         }
     }
     
     void RegisterForAdsCallbacks()
     {
         AdColony.Ads.OnRequestInterstitial += (AdColony.InterstitialAd ad) =>
         {
             _ad = ad;
         };

         AdColony.Ads.OnExpiring += (AdColony.InterstitialAd ad) =>
         {
             AdColony.Ads.RequestInterstitialAd(ad.ZoneId, null);
         };

        AdColony.Ads.OnRewardGranted += (string zoneId, bool success, string name, int amount) =>
        {
            ContinuePlaying();
            //gameoverfunctions.GetComponent<GameOverScrn>().RestartLevel();
        };
    }
     
     void RequestAd()
     {
         AdColony.AdOptions adOptions = new AdColony.AdOptions();
         adOptions.ShowPrePopup = true;
         adOptions.ShowPostPopup = true;
         if (Application.platform == RuntimePlatform.Android ||
         Application.platform == RuntimePlatform.IPhonePlayer)
         {
             AdColony.Ads.RequestInterstitialAd(zoneIDs[0], adOptions);
         }
     }

     void PlayAdv()
     {
         if (_ad != null)
         {
             AdColony.Ads.ShowAd(_ad);
            StartCoroutine(restarWait());
        }
     }

     void RequestAdReward()
     {
         AdColony.AdOptions adOptions = new AdColony.AdOptions();
         adOptions.ShowPrePopup = true;
         adOptions.ShowPostPopup = true;

         AdColony.Ads.RequestInterstitialAd(zoneIDs[1], adOptions);
     }

     void RegisterForAdsCallbacksReward()
     {

         // Other event registrations...

         AdColony.Ads.OnRewardGranted += (string zoneId, bool success, string name, int amount) =>
         {
             
         };
     }
     private IEnumerator PlayStreamingVideo(string url)
     {
         Handheld.PlayFullScreenMovie(url, Color.black, FullScreenMovieControlMode.Full, FullScreenMovieScalingMode.AspectFill);
         yield return new WaitForEndOfFrame();
         yield return new WaitForEndOfFrame();
         Debug.Log("Video playback completed.");
     }

    public void ContinuePlaying()
    {
        StartCoroutine(WaitSeconds());
        this.oldplayer = GameObject.FindGameObjectWithTag("Player");
        this.healthbar.GetComponent<Slider>().value = 1.0f;
        this.oldplayer.GetComponent<HealthSystem>().AddHealth(20);
        this.oldplayer.GetComponent<HealthSystem>().invulnerable = true;
        this.oldplayer.GetComponent<PlayerMovement>().revived();
        this.oldplayer.GetComponent<PlayerCombat>().Revived();
        this.gameoverscreen.SetActive(false);
        this.controls.SetActive(true);
        this.hud.SetActive(true);
       // Debug.Log("visible");
        this.enemies = GameObject.FindGameObjectWithTag("Enemies");
        StartCoroutine(WaitToMove());
       
    }
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(EnemiesShow());
    }
    IEnumerator EnemiesShow()
    {
        this.Counter.gameObject.SetActive(true);
        this.Counter.text = "3";
        yield return null;
        if (enemies != null)
        {
            foreach (Transform child in this.enemies.gameObject.transform)
            {
                try
                {
                    child.gameObject.GetComponent<EnemyAI>().enableAI = false;
                    child.gameObject.GetComponent<HealthSystem>().invulnerable = true;
                }
                catch { }
            }
            yield return new WaitForSeconds(1);
            for (int i=0; i<2; i++)
            {
                yield return new WaitForSeconds(1);
                this.Counter.text = int.Parse(this.Counter.text) -1 + "";
            }
            yield return new WaitForSeconds(1);
            this.Counter.text = "¡GO!";
            yield return new WaitForSeconds(1);
            this.Counter.text = "";
            foreach (Transform child in this.enemies.gameObject.transform)
            {
                try
                {
                    child.gameObject.GetComponent<EnemyAI>().enableAI = true;
                    child.gameObject.GetComponent<HealthSystem>().invulnerable = false;
                    this.oldplayer.GetComponent<HealthSystem>().invulnerable = false;
                }
                catch { }
            }
        }
        this.Counter.gameObject.SetActive(false);
    }
}
