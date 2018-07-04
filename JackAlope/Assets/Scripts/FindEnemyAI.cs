using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemyAI : MonoBehaviour {

    // Use this for initialization
    public GameObject enemy;
	void Start () {
        this.gameObject.GetComponent<EnemyAI>().target = null;
    }
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.GetComponent<EnemyAI>().target == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            this.gameObject.GetComponent<EnemyAI>().target = enemy;
        }
	}
}
