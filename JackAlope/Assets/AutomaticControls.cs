using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticControls : MonoBehaviour {

    // Use this for initialization
    public bool updateEveryFrame = false;
    private bool pressed;
    public float attackInterval =0.5f;
    public float maxDistance = 1.5f;
    public GameObject player,enemy;
    public GameObject [] Targets;
    public GameObject Jump_Button, Defend_Button, JoyStick;

    void Start () {
        prevInterval = attackInterval;
        Debug.Log(prevInterval);
    }
    IEnumerator FightAutomatic(float attackInterval)
    {
        float rand = Random.Range(0, 2);
        yield return new WaitForSeconds(attackInterval);
        if (rand == 0)
        {
            Punch();
        }
        if (rand == 1)
        {
            Kick();
        }
        if (rand == 2)
        {
            Jump();
        }
        if (rand == 3)
        {
            Defend();
        }
    }
	
    public void Punch()
    {
        INPUTACTION actionDown = INPUTACTION.PUNCH;
        InputManager.CombatInputEvent(actionDown);
        pressed = true;
        StartCoroutine(AtackTime());
        Debug.Log("Punching");
    }
    public void Kick()
    {
        INPUTACTION actionDown = INPUTACTION.KICK;
        InputManager.CombatInputEvent(actionDown);
        pressed = true;
        StartCoroutine(AtackTime());
        Debug.Log("Kicking");
    }
    public void Jump()
    {
        INPUTACTION actionDown = INPUTACTION.JUMP;
        InputManager.CombatInputEvent(actionDown);
        pressed = true;
        StartCoroutine(AtackTimeJump());
        Debug.Log("Jumping");
    }
    public void Defend()
    {
        INPUTACTION actionDown = INPUTACTION.DEFEND;
        updateEveryFrame = true;
        InputManager.CombatInputEvent(actionDown);
        pressed = true;
        StartCoroutine(AtackTime());
        Debug.Log("Defending");
    }
    IEnumerator AtackTimeJump()
    {
        yield return new WaitForSeconds(2);
        INPUTACTION actionUp = INPUTACTION.NONE;
        InputManager.CombatInputEvent(actionUp);
        pressed = false;
    }
    IEnumerator AtackTime()
    {
        yield return new WaitForSeconds(1);
        INPUTACTION actionUp = INPUTACTION.NONE;
        InputManager.CombatInputEvent(actionUp);
        pressed = false;
        updateEveryFrame = false;
    }
    // Update is called once per frame

    private float timer;
    private float prevInterval;
	void Update () {
        if (updateEveryFrame) InputManager.OnDefendButtonPress(pressed);
        if (player == null)
        {
            try
            {
                this.player = GameObject.FindGameObjectWithTag("Player");
            }
            catch { }
        }
        if (this.Targets.Length <= 0)
        {
            this.Targets = new GameObject[5];
        }
        if (Targets[0] == null)
        {
           
            try
            {
                Targets = GameObject.FindGameObjectsWithTag("Enemy");
            }
            catch { }
        }
        try
        {
            if (Vector3.Distance(this.player.transform.position, this.Targets[0].transform.position) <= this.maxDistance)
            {
                this.enemy = this.Targets[0];
            }
            else if (Vector3.Distance(this.player.transform.position, this.Targets[1].transform.position) <= this.maxDistance)
            {
                this.enemy = this.Targets[1];
            }
            else if (Vector3.Distance(this.player.transform.position, this.Targets[2].transform.position) <= this.maxDistance)
            {
                this.enemy = this.Targets[2];
            }
            else if (Vector3.Distance(this.player.transform.position, this.Targets[3].transform.position) <= this.maxDistance)
            {
                this.enemy = this.Targets[3];
            }
            else if (Vector3.Distance(this.player.transform.position, this.Targets[4].transform.position) <= this.maxDistance)
            {
                this.enemy = this.Targets[4];
            }

            if (this.Defend_Button.GetComponent<UIButton>().pressed || this.Jump_Button.GetComponent<UIButton>().pressed)
            {
                attackInterval = 0;
            }
            if (Vector3.Distance(this.player.transform.position, this.enemy.transform.position) <= this.maxDistance && this.enemy.GetComponent<HealthSystem>().CurrentHp > 0 && !this.Jump_Button.GetComponent<UIButton>().pressed && !this.Defend_Button.GetComponent<UIButton>().pressed && !JoyStick.GetComponent<UIJoystick>().isUsing)
            {
                timer += Time.deltaTime;
                if (timer > attackInterval)
                {
                    timer = 0;
                    float rand = Random.Range(0, 2);
                    if (rand == 0)
                    {
                        Punch();
                    }
                    if (rand == 1)
                    {
                        Kick();
                    }
                    if (rand == 2)
                    {
                        Jump();
                    }
                    if (rand == 3)
                    {
                        Defend();
                    }
                }
                if (attackInterval == 0)
                {
                    attackInterval = prevInterval;
                }
            }
        }
        catch { }
       

    }
}
