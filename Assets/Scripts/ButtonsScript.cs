using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour {

    GameObject gameController;
    GameObject trump;

    GameObject america;

    // if changing, change on WallScript, ButtonsScript, GameControllerScript, TrumpScript
    //public int putinCost = 2000;
    //public int wallCost = 500;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController");
        trump = GameObject.Find("Trump");

        america = GameObject.Find("America");
    }
	
	// Update is called once per frame
	void Update () {
        if (gameController.GetComponent<GameControllerScript>().gold >= gameController.GetComponent<GameControllerScript>().wallCost && this.gameObject.name == "WallButton"
            && !america.GetComponent<AmericaScript>().buttonsDisabled)
        {
            this.GetComponent<Button>().interactable = true;
        }
        else if (gameController.GetComponent<GameControllerScript>().gold < gameController.GetComponent<GameControllerScript>().wallCost && this.gameObject.name == "WallButton")
        {
            this.GetComponent<Button>().interactable = false;
        }
        if (gameController.GetComponent<GameControllerScript>().gold >= gameController.GetComponent<GameControllerScript>().putinCost && this.gameObject.name == "PutinButton"
            && !america.GetComponent<AmericaScript>().buttonsDisabled)
        {
            this.GetComponent<Button>().interactable = true;
        }
        else if (gameController.GetComponent<GameControllerScript>().gold < gameController.GetComponent<GameControllerScript>().putinCost && this.gameObject.name == "PutinButton")
        {
            this.GetComponent<Button>().interactable = false;
        }

        if (trump.GetComponent<TrumpScript>().putinPlaying)
        {
            GameObject.Find("PutinButton").GetComponent<Button>().interactable = false;
            GameObject.Find("WallButton").GetComponent<Button>().interactable = false;
        }
    }
}
