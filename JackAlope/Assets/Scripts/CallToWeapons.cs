using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallToWeapons : MonoBehaviour {

	// Use this for initialization
	void Start () {
        try
        {
            GameObject.FindGameObjectWithTag("AdWeapon").GetComponent<PlayerGetWeapon>().CheckForWeapon();
        }
        catch { }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
