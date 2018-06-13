using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCelebrate : MonoBehaviour {
    public GameObject effect, items, vfx;
	// Use this for initialization
	void Awake () {
        items = GameObject.FindGameObjectWithTag("ITEMS");
        items.SetActive(false);
        vfx = GameObject.FindGameObjectWithTag("VFX");
        vfx.SetActive(false);
        effect = GameObject.FindGameObjectWithTag("Confetti");
        effect.GetComponent<ParticleSystem>().Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (effect == null)
        {
            items = GameObject.FindGameObjectWithTag("ITEMS");
            items.SetActive(false);
            vfx = GameObject.FindGameObjectWithTag("VFX");
            vfx.SetActive(false);
            effect = GameObject.FindGameObjectWithTag("Confetti");
            effect.GetComponent<ParticleSystem>().Play();
        }
	}
}
