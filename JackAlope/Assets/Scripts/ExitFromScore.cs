using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitFromScore : MonoBehaviour {

    // Use this for initialization
    public GameObject CompleteScreen, Homebutton, PlayWithTwiceHealth, ScoreWindow;

    private void OnEnable()
    {
        StartCoroutine(CheckForScore());
    }
    IEnumerator CheckForScore()
    {
        GlobalAudioPlayer.PlaySFX("ScoreCount");
        yield return new WaitForSeconds(1.3f);
        if(this.gameObject.GetComponent<Text>().text == this.GetComponent<ScoreSystem>().currentScore + "")
        {
            GlobalAudioPlayer.PlaySFX("Reward");
            yield return new WaitForSeconds(3);
            this.ScoreWindow.SetActive(false);
            this.CompleteScreen.SetActive(true);
            this.Homebutton.SetActive(true);
            this.PlayWithTwiceHealth.SetActive(true);
        }
        else
        {
            StartCoroutine(CheckForScore());
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
