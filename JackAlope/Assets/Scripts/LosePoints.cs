using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePoints : MonoBehaviour {

    // Use this for initialization
    public GameObject ScoreSystem;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseAllPoints()
    {
        ScoreSystem.GetComponent<ScoreSystem>().currentScore = 0;
        this.gameObject.GetComponent<SavingPoints>().savingPoints = 0;
        this.gameObject.GetComponent<SavingPoints>().currentPoints = 0;
    }
}
