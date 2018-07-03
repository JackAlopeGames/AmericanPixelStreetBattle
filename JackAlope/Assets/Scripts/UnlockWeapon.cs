using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWeapon : MonoBehaviour {

    // Use this for initialization
    public GameObject banner;
	void OnEnable () {
        try
        {
            if (GameObject.FindGameObjectWithTag("GunIsAvailable").GetComponent<GunIsAvailable>().GunIsAvailables)
            {
                this.gameObject.SetActive(false);
                banner.SetActive(false);
            }
        }
        catch { }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
