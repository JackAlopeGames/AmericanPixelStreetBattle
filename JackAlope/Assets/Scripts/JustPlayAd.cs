using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using Heyzap;
using AdColony;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JustPlayAd : MonoBehaviour
{

    int rand;
    public string[] zoneIDs = new string[] { "vz724467f142854a3d94", "vzb30111684a9643cfa7" };
    public string AppID = "app6a252394f52f458a9c";
    AdColony.InterstitialAd _ad = null;

    public void WatchADs()
    {
        rand = Random.Range(0, 3);

#if UNITY_ANDROID
        if (rand == 0)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Initialize("2586763");
                Debug.Log(Advertisement.gameId);
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
                    LoadNextLevel();
                    /*Debug.Log("Player gain 5 GEMS");
                    go = GameObject.FindGameObjectWithTag("GameOver");
                    go.GetComponent<GameOverScrn>().RestartLevel();*/

                    //  gameoverfunctions.GetComponent<GameOverScrn>().RestartLevel();
                }
            }

        }
        if (rand == 2)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            // [AdColony]
            ConfigureAds();
            RegisterForAdsCallbacks();
            RequestAdReward();
            PlayAdv();
        }
        if (rand == 3)
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
                    LoadNextLevel();
                    /*Debug.Log("Player gain 5 GEMS");
                    go = GameObject.FindGameObjectWithTag("GameOver");
                    go.GetComponent<GameOverScrn>().RestartLevel();*/

                    //  gameoverfunctions.GetComponent<GameOverScrn>().RestartLevel();
                }
            }
        }
#endif

    }

    IEnumerator restarWait()
    {
        yield return new WaitForSeconds(1f);
        LoadNextLevel();
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
            LoadNextLevel();

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

            LoadNextLevel();
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
                LoadNextLevel();

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
        appOptions.AdOrientation = AdColony.AdOrientationType.AdColonyOrientationLandscape;
        if (Application.platform == RuntimePlatform.Android ||
        Application.platform == RuntimePlatform.IPhonePlayer)
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
            LoadNextLevel();
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
        else
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Initialize("2586763");
                Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
            }
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


    public void LoadNextLevel()
    {
        if (SceneManager.GetSceneByName("MainMenu").isLoaded)
        {
            SceneManager.LoadScene("PhaseOne");
        }
        else if (SceneManager.GetSceneByName("PhaseOne").isLoaded)
        {
            SceneManager.LoadScene("Level_1");
        }
        else if (SceneManager.GetSceneByName("Level_1").isLoaded)
        {
            SceneManager.LoadScene("Level_2");
        }
        else if (SceneManager.GetSceneByName("Level_2").isLoaded)
        {
            SceneManager.LoadScene("Level_3");
        }
        else if (SceneManager.GetSceneByName("Level_3").isLoaded)
        {
            SceneManager.LoadScene("Level_4");
        }
        else if (SceneManager.GetSceneByName("Level_4").isLoaded)
        {
            SceneManager.LoadScene("Level_5");
        }
        else if (SceneManager.GetSceneByName("Level_5").isLoaded)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
   
}
