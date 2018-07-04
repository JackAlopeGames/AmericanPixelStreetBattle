using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainEnergy : MonoBehaviour {

    // Use this for initialization
    public GameObject SpecialAttack;
    public GameObject [] enemies;
    public GameObject player, playerSP;
    public GameObject Mask;
    public GameObject button, thunder;
    public GameObject fader;
    private bool EveryoneIsDead;
    private GameObject items;
    public GameObject CounterRespawn;
    void Start () {
		
	}

    public void GainEnergyPunch(float x)
    {
        this.GetComponent<Slider>().value += x;

        if (this.GetComponent<Slider>().value >= 1)
        {
            this.button.SetActive(true);
            this.thunder.SetActive(true);
        }
    }

    public GameObject[] restrictors;

    public void DoSpecialMove()
    {
        this.enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (this.enemies.Length >0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<HealthSystem>().CurrentHp > 0)
                {
                    EveryoneIsDead = false;
                }
                else
                {
                    EveryoneIsDead = true;
                }
            }

            if (EveryoneIsDead || this.CounterRespawn.GetComponent<isCounterActive>().isActive)
            {
                return;
            }
            items = GameObject.FindGameObjectWithTag("ITEMS");
            restrictors = GameObject.FindGameObjectsWithTag("Restrictors");
            for (int i = 0; i < restrictors.Length; i++)
            {
                this.restrictors[i].SetActive(false);
            }

            this.GetComponent<Slider>().value = 0;
            
            this.player = GameObject.FindGameObjectWithTag("Player");
            for (int i = 0; i < enemies.Length; i++)
            {
                this.enemies[i].GetComponent<EnemyAI>().enableAI = false;
            }
            this.player.GetComponent<Rigidbody>().useGravity = false;
            this.player.GetComponent<Rigidbody>().isKinematic = true;
            this.player.GetComponent<CapsuleCollider>().enabled = false;
            this.Mask.SetActive(true);

            StartCoroutine(waitToSpecial());
        }
    }

    IEnumerator waitToSpecial()
    {
        yield return new WaitForEndOfFrame();
        this.player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("SpecialAttack");
        yield return new WaitForSeconds(2);
        this.SpecialAttack.GetComponent<Animator>().SetTrigger("SP");
        yield return new WaitForSeconds(2);
        items.SetActive(false);
        this.player.SetActive(false);
        for (int i = 0; i < enemies.Length; i++)
        {
            // this.enemies[i].GetComponent<HealthSystem>().SubstractHealth(100);
            if (i >= 4)
            {
                this.enemies[i].transform.position = new Vector3(this.player.transform.position.x - 5.5f, this.enemies[i].transform.position.y, (this.playerSP.transform.position.z - 2.5f) + i - 4);
            }
            else if (i >= 2)
            {
                this.enemies[i].transform.position = new Vector3(this.player.transform.position.x - 4.5f, this.enemies[i].transform.position.y, (this.playerSP.transform.position.z - 2.5f) + i-2);
            }
            else
            {
                this.enemies[i].transform.position = new Vector3(this.player.transform.position.x - 3.5f, this.enemies[i].transform.position.y, (this.playerSP.transform.position.z - 2.5f) + i);
            }
        }
        GameObject firesp = GameObject.FindGameObjectWithTag("FireSP");
        firesp.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        firesp.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        GameObject playerspClone = Instantiate(this.playerSP, new Vector3(this.player.transform.position.x + 3.5f, this.playerSP.transform.position.y, this.playerSP.transform.position.z), Quaternion.identity);
        if(GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyWaveSystem>().currentWave == 4 || GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyWaveSystem>().currentWave == 5)
        {
           playerspClone.GetComponent<EnemyAI>().AttackList[0].damage = this.enemies[0].GetComponent<HealthSystem>().MaxHp /24;
        }
        yield return new WaitForSeconds(2f); // time to kill them
         this.player.GetComponent<Rigidbody>().useGravity = true;
        this.player.GetComponent<Rigidbody>().isKinematic = false;
        this.player.GetComponent<CapsuleCollider>().enabled = true;
        this.Mask.SetActive(false);
        this.fader.GetComponent<UIFader>().Fade(UIFader.FADE.FadeOut, 1, 0);
        firesp.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        firesp.transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
        GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>().currentScore += 200.0f;
        yield return new WaitForSeconds(1);
        items.SetActive(true);
        playerspClone.SetActive(false);
        this.player.SetActive(true);
        for (int i = 0; i < enemies.Length; i++)
        {
            this.enemies[i].GetComponent<EnemyAI>().enableAI = true;
            this.enemies[i].GetComponent<EnemyAI>().enemyState = UNITSTATE.WALK;
            this.enemies[i].transform.GetChild(1).GetComponent<Animator>().SetTrigger("Idle");
        }
        this.fader.GetComponent<UIFader>().Fade(UIFader.FADE.FadeIn, 1, 0);
        for (int i = 0; i < restrictors.Length; i++)
        {
            this.restrictors[i].SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
