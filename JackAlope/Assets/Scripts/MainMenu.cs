using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // Use this for initialization
    public UIFader UI_fader;
    [Header("HUD Portrait")]
    public Sprite HUDPortrait;

    [Header("GameOver Portrait")]
    public Sprite GameOverPortrait;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartPlay()
    {
        GlobalAudioPlayer.PlaySFX("ItemPickup");
        UI_fader.Fade(UIFader.FADE.FadeOut, 2f, 0f);

        StartCoroutine(fadeWait());
    }

    IEnumerator fadeWait()
    {
        yield return new WaitForSeconds(2);
        // SceneManager.LoadScene("CharSelect");
        GlobalPlayerData.PlayerHUDPortrait = HUDPortrait;
        GlobalPlayerData.PlayerGameOver = GameOverPortrait;
        SceneManager.LoadScene("PhaseOne");
    }

    public void PlayReward()
    {
        GlobalAudioPlayer.PlaySFX("ItemPickup");
        GlobalPlayerData.PlayerHUDPortrait = HUDPortrait;
        GlobalPlayerData.PlayerGameOver = GameOverPortrait;
    }
    public void Weapons()
    {

    }
    
}
