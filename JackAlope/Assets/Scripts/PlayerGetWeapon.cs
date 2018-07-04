using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetWeapon : MonoBehaviour {

    // Use this for initialization

    public bool AdForWeapon;
    public bool gunB, plankB, pipeB, bottleB;
    public GameObject gun, plank, pipe, bottle;
    public GameObject mask;

    public void ControlThisButton()
    {
        this.mask.SetActive(true);
        StartCoroutine(MaskWait());
    }

    IEnumerator MaskWait()
    {
        yield return new WaitForSeconds(1);
        this.mask.SetActive(false);
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetGun()
    {
        gunB = true;
        plankB = false;
        pipeB = false;
        bottleB = false;
        AdForWeapon = true;
    }
    public void SetPipe()
    {
        gunB = false;
        plankB = false;
        pipeB = true;
        bottleB = false;
        AdForWeapon = true;
    }
    public void SetBottle()
    {
        gunB = false;
        plankB = false;
        pipeB = false;
        bottleB = true;
        AdForWeapon = true;
    }
    public void SetPlank()
    {
        gunB = false;
        plankB = true;
        pipeB = false;
        bottleB = false;
        AdForWeapon = true;
    }
    public void CheckForWeapon()
    {
        if (AdForWeapon)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (gunB)
            {
                GameObject clone =  Instantiate(gun, player.transform.position, Quaternion.identity);
                clone.GetComponent<WeaponPickup>().weapon.timesToUse = 6;
                gunB = !gunB;
            }
            else if (plankB)
            {
                GameObject clone = Instantiate(plank, player.transform.position, Quaternion.identity);
                clone.GetComponent<WeaponPickup>().weapon.timesToUse = 6;
                plankB = !plankB;
            }
            else if (pipeB)
            {
                GameObject clone = Instantiate(pipe, player.transform.position, Quaternion.identity);
                clone.GetComponent<WeaponPickup>().weapon.timesToUse = 6;
                pipeB = !pipeB;
            }
            else if (bottleB)
            {
               GameObject clone =  Instantiate(bottle, player.transform.position, Quaternion.identity);
                clone.GetComponent<WeaponPickup>().weapon.damageObject.damage = 12;
               bottleB = !bottleB;
            }
            StartCoroutine(waitForWeapon(player));
            AdForWeapon = !AdForWeapon;
        }
    }

    IEnumerator waitForWeapon(GameObject player)
    {
        yield return new WaitForEndOfFrame();
        player.GetComponent<PlayerCombat>().interactWithItem();
    }
}
