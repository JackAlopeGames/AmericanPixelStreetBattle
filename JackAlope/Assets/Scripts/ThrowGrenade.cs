using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour {

    // Use this for initialization
    public GameObject Grenade;
    public GameObject clone, clone2, clone3;
    public GameObject hand;
    bool throws;
    public float force;
	void Start () {
		
	}
	
    public void ThrowGrenadeEvent()
    {
        throws = true;
        time = 0;
        clone = Instantiate(this.Grenade, this.hand.transform.position, Quaternion.identity);
        if(this.gameObject.transform.parent.GetComponent<PlayerCombat>().currentDirection == DIRECTION.Left)
        {
            clone.GetComponent<Rigidbody>().AddForce(new Vector3(-1.0f,0,0) * -200 + Vector3.up * 400);
        }else if(this.gameObject.transform.parent.GetComponent<PlayerCombat>().currentDirection == DIRECTION.Right)
        {
            clone.GetComponent<Rigidbody>().AddForce(Vector3.left * 200 + Vector3.up * 400);
        }
        Destroy(clone, 2);
    }
    // Update is called once per frame
    public float time;
	void Update () {
        if (throws)
        {
            time += Time.deltaTime;
            if (time < 1)
            {
                try
                {
                    this.clone.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 1000));
                }
                catch { }
            }else
            {
                throws = false;
            }
        }
	}
}
