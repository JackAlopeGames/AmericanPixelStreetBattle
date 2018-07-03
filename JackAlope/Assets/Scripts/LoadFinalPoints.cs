using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFinalPoints : MonoBehaviour
{

    // Use this for initialization
    public GameObject Manager;

    private void OnEnable()
    {
        Manager.GetComponent<SavingPoints>().savingPoints += Manager.GetComponent<SavingPoints>().currentPoints;
        this.gameObject.GetComponent<ScoreSystem>().currentScore = 0;
        this.gameObject.GetComponent<ScoreSystem>().currentScore += Manager.GetComponent<SavingPoints>().savingPoints;
        GlobalAudioPlayer.PlaySFX("ScoreCount");
    }
}
    
