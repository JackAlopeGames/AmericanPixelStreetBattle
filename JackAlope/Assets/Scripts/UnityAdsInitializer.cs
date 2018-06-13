using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using Heyzap;
using UnityEngine.SceneManagement;

public class UnityAdsInitializer : MonoBehaviour
{
    [SerializeField]
    private string
        androidGameId = "2586763";

    [SerializeField]
    private bool testMode;

    void Start()
    {
#if UNITY_ANDROID
        HeyzapAds.Start("1cfd278f7ac1867f34afbb636aadb0bb", HeyzapAds.FLAG_NO_OPTIONS);
        Heyzap.HeyzapAds.ShowDebugLogs();
        HZIncentivizedAd.Fetch();


        string gameId = null;


        gameId = androidGameId;

        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId, testMode);
        }

        AppLovin.InitializeSdk();
        AppLovin.PreloadInterstitial();
        AppLovin.LoadRewardedInterstitial("4bcd90e276831a9d");


        AdColony.AppOptions appOptions = new AdColony.AppOptions();
        appOptions.UserId = "foo";
        appOptions.AdOrientation = AdColony.AdOrientationType.AdColonyOrientationAll;

        string[] zoneIds = new string[] { "vzb30111684a9643cfa7", "vz724467f142854a3d94" };

        AdColony.Ads.Configure("app6a252394f52f458a9c", appOptions, zoneIds);
#endif
    }
    public IEnumerator LocationStart()
    {
        UnityEngine.Debug.Log("location service start");
        // First, check if user has location service enabled
        // if (!Input.location.isEnabledByUser){
        //     console.Append("Location disabled by user... quitting");
        //     yield break;
        // }

        // Start service before querying location
        Debug.Log("Starting location service");
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            Debug.Log("still initializing location");
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Location Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
}
