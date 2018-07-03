using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartThisLevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("UI"));
        if (SceneManager.GetSceneByName("PhaseOne").isLoaded)
        {
            SceneManager.LoadScene("PhaseOne");
        }
        else if (SceneManager.GetSceneByName("Level_1").isLoaded)
        {
            SceneManager.LoadScene("Level_1");
        }
        else if (SceneManager.GetSceneByName("Level_2").isLoaded)
        {
            SceneManager.LoadScene("Level_2");
        }
        else if (SceneManager.GetSceneByName("Level_3").isLoaded)
        {
            SceneManager.LoadScene("Level_3");
        }
        else if (SceneManager.GetSceneByName("Level_4").isLoaded)
        {
            SceneManager.LoadScene("Level_4");
        }
        else if (SceneManager.GetSceneByName("Level_5").isLoaded)
        {
            SceneManager.LoadScene("Level_5");
        }
    }
}
