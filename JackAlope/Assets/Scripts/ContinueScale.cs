using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScale : MonoBehaviour {

    // Use this for initialization
    public float delta = .002f;  // Amount to move left and right from the start point
    public float speed = 4f;
    private Vector3 startScale;

    void Start () {
        this.startScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = this.startScale;
        v.x += delta * Mathf.Sin(Time.time * speed);
        v.y += delta * Mathf.Sin(Time.time * speed);
        v.z += delta * Mathf.Sin(Time.time * speed);
        transform.localScale = v;
    }
}
