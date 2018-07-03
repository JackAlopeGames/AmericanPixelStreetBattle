using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour {

    // Use this for initialization
    public Text text;
    public Gradient ColorTransition;
    public float speed = 3.5f;
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
