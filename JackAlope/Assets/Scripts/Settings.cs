using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    // Use this for initialization

    public GameObject Music;
    public GameObject SoundFX;
    public GameObject MbutOn, MbutOff,FXbutOn,FXbutOff;
    bool MusicB = true;
    bool SoundFXB = true;
	void Start () {
        this.SoundFX = GameObject.FindGameObjectWithTag("AudioPlayer");
        try
        {
            this.Music = GameObject.FindGameObjectWithTag("Music");

            if (this.Music.GetComponent<AudioSource>().mute == true)
            {
                this.MusicB = false;
                MbutOff.SetActive(true);
                MbutOn.SetActive(false);
            }
            if (this.SoundFX.GetComponent<AudioSource>().mute == true)
            {
                this.MusicB = false;
                FXbutOff.SetActive(true);
                FXbutOn.SetActive(false);
            }
        }
        catch { }
    }
	
    public void MusicSwitch()
    {
        GlobalAudioPlayer.PlaySFX("POP");
        if (MusicB)
        {
            this.Music.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            this.Music.GetComponent<AudioSource>().mute = false;
        }
        this.MusicB = !this.MusicB;
    }

    public void SoundFXSwitch()
    {
        GlobalAudioPlayer.PlaySFX("POP");
        if (SoundFXB)
        {
            this.SoundFX.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            this.SoundFX.GetComponent<AudioSource>().mute = false;
        }
        this.SoundFXB = !this.SoundFXB;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
