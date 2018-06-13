using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameOverScrn : MonoBehaviour
{

    public Text text;
    public Gradient ColorTransition;
    public float speed = 3.5f;
    public UIFader fader;
    public GameObject enemies, hud,butto;
    private bool restartInProgress = false;

    private void OnEnable()
    {
        this.button = butto.GetComponent<Image>();
        /*enemies = GameObject.FindGameObjectWithTag("Enemies");
        this.enemies.SetActive(false);*/
        try
        {
            hud = GameObject.FindGameObjectWithTag("HUD");
            this.hud.SetActive(false);
        }
        catch { }
        
        InputManager.onCombatInputEvent += InputEvent;
    }

    private void OnDisable()
    {
        InputManager.onCombatInputEvent -= InputEvent;
    }

    //input event
    private void InputEvent(INPUTACTION action)
    {
        if (action == INPUTACTION.PUNCH || action == INPUTACTION.KICK) RestartLevel();
    }

    public Image button;
    void Update()
    {

        //text effect
        if (text != null && text.gameObject.activeSelf)
        {
            float t = Mathf.PingPong(Time.time * speed, 1f);
            text.color = ColorTransition.Evaluate(t);

            float t2 = Mathf.PingPong(Time.time * (speed/2), 1f);
            button.color = ColorTransition.Evaluate(t2);
        }

        //alternative input events
        /* if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
         {
             RestartLevel();
         }*/
    }

    //restarts the current level
    public void RestartLevel()
    {
        if (!restartInProgress)
        {
            restartInProgress = true;

            //sfx
            GlobalAudioPlayer.PlaySFX("ButtonStart");

            //button flicker
            ButtonFlicker bf = GetComponentInChildren<ButtonFlicker>();
            if (bf != null) bf.StartButtonFlicker();

            //fade out  
            fader.Fade(UIFader.FADE.FadeOut, 0.5f, 0.5f);

            //reload level
            Invoke("RestartScene", 1f);
        }
    }
    void RestartScene()
    {
        restartInProgress = false;
        //PREVIOUS OPTION TRY StartCoroutine(PlayStreamingVideo("video.mp4"));
        //Handheld.PlayFullScreenMovie("video.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
