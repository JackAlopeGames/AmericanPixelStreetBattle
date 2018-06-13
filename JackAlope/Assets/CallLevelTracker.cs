using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallLevelTracker : MonoBehaviour {

    // Use this for initialization

    public GameObject lvl1, lvl2, lvl3, lvl4, lvl5, lvl6;
	void Start () {
		
	}
	
    public void CallLevel()
    {
        if (SceneManager.GetSceneByName("PhaseOne").isLoaded)
        {
            lvl1.SetActive(true);
        }
        else if (SceneManager.GetSceneByName("Level_1").isLoaded)
        {
            lvl2.SetActive(true);
        }
        else if (SceneManager.GetSceneByName("Level_2").isLoaded)
        {
            lvl3.SetActive(true);
        }
        else if (SceneManager.GetSceneByName("Level_3").isLoaded)
        {
            lvl4.SetActive(true);
        }
        else if (SceneManager.GetSceneByName("Level_4").isLoaded)
        {
            lvl5.SetActive(true);
        }
        else if (SceneManager.GetSceneByName("Level_5").isLoaded)
        {
            lvl6.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
