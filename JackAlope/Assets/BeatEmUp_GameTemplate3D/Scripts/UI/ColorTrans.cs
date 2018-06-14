using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTrans : MonoBehaviour {
    public Text text;
    public Gradient ColorTransition;
    public float speed = 3.5f;
    public GameObject button;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //text effect
        if (text != null && text.gameObject.activeSelf)
        {
            float t = Mathf.PingPong(Time.time * speed, 1f);
            text.color = ColorTransition.Evaluate(t);
            
        }
    }
}
