using UnityEngine;
using UnityEngine.UI;

public class PortraitGameOver : MonoBehaviour {

	public Image playerPortrait;

	void Start () {
        playerPortrait.sprite = null;
		//loads the icon of the player that was selected in the character selection screen
		if(playerPortrait && GlobalPlayerData.PlayerGameOver){
			playerPortrait.overrideSprite = GlobalPlayerData.PlayerGameOver;
		}
	}

    void Update()
    {
        if(playerPortrait.sprite== null)
        {
            playerPortrait.sprite = GlobalPlayerData.PlayerGameOver;
        }
    }
}
