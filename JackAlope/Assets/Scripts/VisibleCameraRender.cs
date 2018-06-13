using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleCameraRender : MonoBehaviour {

    // Use this for initialization
    ParticleSystem a;
    Renderer r;
	void Start () {
        a = this.GetComponent<ParticleSystem>();
        r = this.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (r.isVisible)
        {
            //Debug.Log("Visible");
            if (!a.isPlaying)
            { 
                a.Play();
            }
        }
        else
        {
            //ebug.Log("Not visible");
            if (a.isPlaying)
            {
                a.Pause();
            }
        }
    }
    
}
