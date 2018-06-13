using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    bool pause;
	// Use this for initialization
	void Start () {
		
	}
	
    public void ButtonPause()
    {
        pause = !pause;
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void HomeButton()
    {
        Destroy(GameObject.FindGameObjectWithTag("UI"));
        SceneManager.LoadScene("MainMenu");
     
    }

	// Update is called once per frame
	void Update () {
		
	}
}
