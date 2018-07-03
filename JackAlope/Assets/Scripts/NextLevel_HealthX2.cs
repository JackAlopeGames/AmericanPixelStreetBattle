using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel_HealthX2 : MonoBehaviour {

    // Use this for initialization
    public GameObject cheker;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetNextDoubleHealth()
    {
        GlobalAudioPlayer.PlaySFX("ItemPickup");
        try
        {
            cheker.GetComponent<getExtraCheker>().cheker.GetComponent<ExtraLife>().extra = true;
            cheker.GetComponent<getExtraCheker>().cheker.GetComponent<ExtraLife>().UpdateExtra();
        }
        catch { }

    }
}
