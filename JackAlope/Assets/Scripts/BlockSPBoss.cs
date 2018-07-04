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

    private bool EveryoneIsDead;
    public void CheckForWave()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
      
        
        if (enemies.Length <= 0)
        {
            //block this
            StartCoroutine(showInstruction());
        }
        for(int i =0; i < enemies.Length; i++)
        {
            if(enemies[i].GetComponent<HealthSystem>().CurrentHp > 0)
            {
                EveryoneIsDead = false;
            }else
            {
                EveryoneIsDead = true;
            }
        }

        if (EveryoneIsDead)
        {
            StartCoroutine(showInstruction());
            EveryoneIsDead = false;
        }
    }

    IEnumerator showInstruction()
    {
        this.Instrunction.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        this.Instrunction.SetActive(false);
    }
}
