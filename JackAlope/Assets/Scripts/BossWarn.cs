using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWarn : MonoBehaviour {

    // Use this for initialization

    public GameObject BossWarning;
	void Start () {
	}

    public void showWarn()
    {
        BossWarning.SetActive(true);
        StartCoroutine(flickr());
    }
	IEnumerator flickr()
    {
        yield return new WaitForSeconds(1f);
        BossWarning.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        BossWarning.SetActive(true);
        yield return new WaitForSeconds(1f);
        BossWarning.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        BossWarning.SetActive(true);
        yield return new WaitForSeconds(1f);
        BossWarning.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
	}
}
