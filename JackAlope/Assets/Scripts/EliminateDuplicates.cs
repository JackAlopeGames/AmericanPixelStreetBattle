using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateDuplicates : MonoBehaviour {

    // Use this for initialization
    public GameObject [] MusicPlayers;

	void OnEnable () {
        this.MusicPlayers = GameObject.FindGameObjectsWithTag("Music");
        if (this.MusicPlayers.Length > 1)
        {
            Destroy(this.MusicPlayers[1]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
