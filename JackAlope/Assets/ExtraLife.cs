using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    public void ExtraLifeActivated()
    {
        this.extra = true;
    }

    public void UpdateExtra()
    {
        if (extra)
        {
            this.ThePlayer.GetComponent<HealthSystem>().ExtraHp = 20;

            this.ThePlayer.GetComponent<HealthSystem>().invulnerable = true;

            this.ThePlayer.GetComponent<HealthSystem>().Extra = true;
            this.ExtraBar.SetActive(true);
        }
        else
        {
            this.ThePlayer.GetComponent<HealthSystem>().Extra = false;
            this.ExtraBar.SetActive(false);
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
                this.ExtraBar.SetActive(true);
            }
            else
            {
                this.ThePlayer.GetComponent<HealthSystem>().Extra = false;
                this.ExtraBar.SetActive(false);
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
