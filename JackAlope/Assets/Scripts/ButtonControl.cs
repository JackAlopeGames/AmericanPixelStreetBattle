using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ButtonControl : MonoBehaviour {

    // Use this for initialization

    public GameObject MaskControl;

	void Start () {
	}
	
    public void Controlthisbutton()
    {
        MaskControl.SetActive(true);
        StartCoroutine(wait());

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        MaskControl.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
