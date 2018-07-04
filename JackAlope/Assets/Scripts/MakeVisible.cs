using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisible : MonoBehaviour {

    // Use this for initialization

    public GameObject Extra_healthbar;
	void Start () {
		
	}
	public void enableHealthBar()
    {
        this.Extra_healthbar.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
