using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteEffect : MonoBehaviour {
    public GameObject effect, items, vfx;
    public Text message, levelnumber;
    // Use this for initialization
    void OnEnable()
    {
        

        if (SceneManager.GetSceneByName("PhaseOne").isLoaded)
        {
            levelnumber.text = "LEVEL 1 COMPLETED";
        }
        else if (SceneManager.GetSceneByName("Level_1").isLoaded)
        {
            levelnumber.text = "LEVEL 2 COMPLETED";
        }
        else if (SceneManager.GetSceneByName("Level_2").isLoaded)
        {
            levelnumber.text = "LEVEL 3 COMPLETED";
        }
        else if (SceneManager.GetSceneByName("Level_3").isLoaded)
        {
            levelnumber.text = "LEVEL 4 COMPLETED";
        }
        else if (SceneManager.GetSceneByName("Level_3").isLoaded)
        {
            levelnumber.text = "LEVEL 5 COMPLETED";
        }
        else if (SceneManager.GetSceneByName("Level_5").isLoaded)
        {
            levelnumber.text = "LEVEL 6 COMPLETED";
            message.text = "You've completed all the levels";
        }
        try
        {
            items = GameObject.FindGameObjectWithTag("ITEMS");
            items.SetActive(false);
            vfx = GameObject.FindGameObjectWithTag("VFX");
            vfx.SetActive(false);
            effect = GameObject.FindGameObjectWithTag("GodRay");
            effect.GetComponent<ParticleSystem>().Play();
        }
        catch { }
    }
   
    // Update is called once per frame
    void Update () {
        if (effect == null)
        {
            try
            {
                items = GameObject.FindGameObjectWithTag("ITEMS");
                items.SetActive(false);
                vfx = GameObject.FindGameObjectWithTag("VFX");
                vfx.SetActive(false);
                effect = GameObject.FindGameObjectWithTag("GodRay");
                effect.GetComponent<ParticleSystem>().Play();
            }
            catch { }
        }
    }
}
