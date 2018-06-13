using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownGO : MonoBehaviour {
    public Text Counter;

    // Use this for initialization
    void Start () {
	}
	public IEnumerator CountDown()
    {
        this.Counter.gameObject.SetActive(true);
        this.Counter.text = "15";
        yield return null;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 14; i++)
        {
            yield return new WaitForSeconds(1);
            this.Counter.text = int.Parse(this.Counter.text) - 1 + "";
        }
        yield return new WaitForSeconds(1);
        this.Counter.text = "GAME OVER";
        yield return new WaitForSeconds(1);
        this.Counter.text = "";
        this.Counter.gameObject.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("UI"));
        SceneManager.LoadScene("MainMenu");
    }

    public void CountDownManual()
    {
        StartCoroutine(CountDown());
    }
	// Update is called once per frame
	void Update () {
		
	}
}
