using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel_HealthX2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetNextDoubleHealth()
    {
        GameObject.FindGameObjectWithTag("ExtraCheker").GetComponent<ExtraLife>().extra = true;
        GameObject.FindGameObjectWithTag("ExtraCheker").GetComponent<ExtraLife>().UpdateExtra();

    }
}
