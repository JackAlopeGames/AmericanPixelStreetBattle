using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    [SerializeField]
    Text uiText;
    [SerializeField]
    float counterSpeed = 10f;
    [SerializeField]
    float animationTime = 0.3f;

    public float currentScore;

    [Header("Scaling")]

    [SerializeField]
    AnimationCurve scalingCurve;

    [Header("Color")]

    [SerializeField]
    Gradient colorGradient;

    float showScore = 0;
    float animationT = 1;
    Color originalColor;

    public GameObject Manager;
    void OnEnable()
    {
        this.Manager = GameObject.FindGameObjectWithTag("PoiintsManager");
        this.currentScore = Manager.GetComponent<SavingPoints>().currentPoints + Manager.GetComponent<SavingPoints>().savingPoints;
        

        animationT = 1;
        originalColor = uiText.color;
        uiText.text = showScore.ToString();
    }


    void Update()
    {
        animationT = Mathf.MoveTowards(animationT, 1, Time.deltaTime / animationTime);
        uiText.transform.localScale = Vector3.one * (1 + scalingCurve.Evaluate(animationT));
        Color animationColor = colorGradient.Evaluate(animationT);
        uiText.color = Color.Lerp(originalColor, animationColor, animationColor.a);

        if (!Mathf.Approximately(showScore, currentScore))
        {
            showScore = Mathf.MoveTowards(showScore, currentScore, Time.deltaTime * counterSpeed);
            string scoreText = showScore.ToString("0");
            if (!scoreText.Equals(uiText.text))
            {
                animationT = 0;
                uiText.text = scoreText;
                GameObject.FindGameObjectWithTag("PoiintsManager").GetComponent<SavingPoints>().currentPoints = currentScore - Manager.GetComponent<SavingPoints>().savingPoints;
            }
        }
        
        
    }
}
