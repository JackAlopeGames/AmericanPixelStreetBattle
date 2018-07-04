using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
    public void NextLevel()
    {
        GameObject.FindGameObjectWithTag("PoiintsManager").GetComponent<SavingPoints>().currentPoints = 0;
        GlobalAudioPlayer.PlaySFX("ItemPickup");
        if (SceneManager.GetSceneByName("PhaseOne").isLoaded)
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
            Destroy(GameObject.FindGameObjectWithTag("UI"));
            Destroy(GameObject.FindGameObjectWithTag("AdWeapon"));
            Destroy(GameObject.FindGameObjectWithTag("ExtraCheker"));
            SceneManager.LoadScene("MainMenu");
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
