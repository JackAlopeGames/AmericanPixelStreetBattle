using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour {

    // Use this for initialization
    
    void Start()
    {
        StartCoroutine(PlayStreamingVideo("JackAlopeGames.mp4"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator PlayStreamingVideo(string url)
    {
        Handheld.PlayFullScreenMovie(url, Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.AspectFill);
        yield return new WaitForEndOfFrame();
        Analytics.CustomEvent("CompanyLogo_IntroComplete");
        //Debug.Log("Video playback completed.");
        SceneManager.LoadScene("MainMenu");
    }

}
