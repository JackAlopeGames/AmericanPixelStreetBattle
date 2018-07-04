using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBar : MonoBehaviour {

	// Use this for initialization
    public GameObject cheker;
	void OnEnable () {
        try
        {
            this.cheker = GameObject.FindGameObjectWithTag("ExtraCheker");
            this.cheker.GetComponent<ExtraLife>().UpdateExtra();
        }
        catch { }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
