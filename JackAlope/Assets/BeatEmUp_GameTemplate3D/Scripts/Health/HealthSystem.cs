using UnityEngine;

public class HealthSystem : MonoBehaviour {

    public int MaxHp = 20;
    public int CurrentHp = 20;
    public int ExtraHp;
    public bool invulnerable, Extra;
    public delegate void OnHealthChange(float percentage, GameObject GO);
    public static event OnHealthChange onHealthChange;

    void Start() {
        try
        {
            if (GameObject.FindGameObjectWithTag("ExtraCheker").GetComponent<ExtraLife>().extra)
            {
                this.ExtraHp = 20;
            }
        }
        catch { }
        SendUpdateEvent();
	}

	//substract health
	public void SubstractHealth(int damage){
        if (Extra)
        {
            ExtraHp = Mathf.Clamp(ExtraHp -= damage, 0, MaxHp);
            if (ExtraHp <= 0)
            {
                GameObject.FindGameObjectWithTag("ExtraCheker").GetComponent<ExtraLife>().extra = false;
                GameObject.FindGameObjectWithTag("ExtraCheker").GetComponent<ExtraLife>().UpdateExtra();
                invulnerable = false;
                Extra = false;
                
            }
        }
        if (!invulnerable){

			//reduce hp
			CurrentHp = Mathf.Clamp(CurrentHp -= damage, 0, MaxHp);
            
			//Health reaches 0
			if (isDead()) gameObject.SendMessage("Death", SendMessageOptions.DontRequireReceiver);
		}

        if(this.gameObject.tag == "Enemy" && !invulnerable)
        {
            GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>().currentScore += 10.0f;
            GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<GainEnergy>().GainEnergyPunch(0.015f);
           
        }
		//update Health Event
		SendUpdateEvent();
	}

	//add health
	public void AddHealth(int amount){
		CurrentHp = Mathf.Clamp(CurrentHp += amount, 0, MaxHp);
		SendUpdateEvent();
	}
		
	//health update event
	public void SendUpdateEvent(){
		float CurrentHealthPercentage = 1f/MaxHp * CurrentHp;
		if(onHealthChange != null) onHealthChange(CurrentHealthPercentage, gameObject);
	}

    //death
    bool isDead(){
		return CurrentHp == 0;
	}
}
