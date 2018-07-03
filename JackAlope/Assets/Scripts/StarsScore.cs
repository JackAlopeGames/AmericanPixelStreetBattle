using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsScore : MonoBehaviour {

    // Use this for initialization

    public GameObject star1, star2, star3;
    public float TotalScore, CurrentScore;
    public GameObject Manager;
    public GameObject AudioSource;
    public AudioClip ContinueSong;
    void OnEnable () {
        this.AudioSource = GameObject.FindGameObjectWithTag("Music");
        AudioSource.GetComponent<AudioSource>().Pause();
        GlobalAudioPlayer.PlaySFX("Victory");
        TotalScore = this.Manager.GetComponent<SavingPoints>().savingPoints;
        CurrentScore = this.Manager.GetComponent<SavingPoints>().currentPoints;
        StartCoroutine(StarsLoad());
	}
	
    IEnumerator StarsLoad()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        yield return new WaitForSeconds(1);
        if (CurrentScore >= 500)
        {
            star1.SetActive(true);
            GlobalAudioPlayer.PlaySFX("GunShot");
        }
        yield return new WaitForSeconds(1);
        if (CurrentScore >= 1100)
        {
            star2.SetActive(true);
            GlobalAudioPlayer.PlaySFX("GunShot");
        }
        yield return new WaitForSeconds(1);
        if (CurrentScore >= 1400)
        {
            star3.SetActive(true);
            GlobalAudioPlayer.PlaySFX("GunShot");
        }
        this.AudioSource.GetComponent<AudioSource>().clip = ContinueSong;
        AudioSource.GetComponent<AudioSource>().Play();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
