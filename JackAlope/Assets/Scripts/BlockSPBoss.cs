using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSPBoss : MonoBehaviour {

    public GameObject Instrunction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckForWave()
    {
        GameObject [] enemies=  GameObject.FindGameObjectsWithTag("Enemy");
        if (GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyWaveSystem>().currentWave == 4 || enemies.Length <= 0)
        {
            //block this
            StartCoroutine(showInstruction());
        }
    }

    IEnumerator showInstruction()
    {
        this.Instrunction.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        this.Instrunction.SetActive(false);
    }
}
