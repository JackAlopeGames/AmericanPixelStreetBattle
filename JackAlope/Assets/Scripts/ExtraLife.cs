using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExtraLife : MonoBehaviour {

    // Use this for initialization

    public bool extra;
    public GameObject ThePlayer,ExtraBar;
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(findUI());
	}

    // Update is called once per frame
    void Update() {
        if (!SceneManager.GetSceneByName("MainMenu").isLoaded && extra)
        {
            try
            {
                if (this.ThePlayer.gameObject == null)
                {

                    this.ThePlayer = GameObject.FindGameObjectWithTag("Player");



                    if (extra)
                    {
                        UpdateExtra();
                    }
                }
                if (this.ExtraBar.gameObject == null)
                {

                    this.ExtraBar = GameObject.FindGameObjectWithTag("ExtraHealth");


                    if (extra)
                    {
                        UpdateExtra();
                    }
                }
            }
            catch { }
        }
    }

    public void ExtraLifeActivated()
    {
        this.extra = true;
    }

    public void UpdateExtra()
    {
        StartCoroutine(findUI());
        if (extra)
        {
            this.ThePlayer.GetComponent<HealthSystem>().ExtraHp = 20;

            this.ThePlayer.GetComponent<HealthSystem>().invulnerable = true;

            this.ThePlayer.GetComponent<HealthSystem>().Extra = true;
            try
            {
                this.ExtraBar.SetActive(true);
            }
            catch { }
        }
        else
        {
            try
            {
                this.ThePlayer.GetComponent<HealthSystem>().Extra = false;
                this.ExtraBar.SetActive(false);
            }
            catch { }
        }
     
    } 

    
    IEnumerator findUI()
    {
        yield return new WaitForSeconds(1);
        try
        {
            this.ThePlayer = GameObject.FindGameObjectWithTag("Player");
            this.ExtraBar = GameObject.FindGameObjectWithTag("ExtraHealth");
            if (extra)
            {
                this.ThePlayer.GetComponent<HealthSystem>().ExtraHp = 20;
                this.ThePlayer.GetComponent<HealthSystem>().invulnerable = true;
                this.ThePlayer.GetComponent<HealthSystem>().Extra = true;
                this.ExtraBar.transform.GetChild(0).GetComponent<Image>().enabled = true;
                this.ExtraBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            }
            else
            {
                this.ThePlayer.GetComponent<HealthSystem>().Extra = false;
                this.ExtraBar.transform.GetChild(0).GetComponent<Image>().enabled = false;
                this.ExtraBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
        catch
        {

        }
        if(this.ThePlayer == null || ExtraBar == null)
        {
            StartCoroutine(findUI());
        }
    }
}
