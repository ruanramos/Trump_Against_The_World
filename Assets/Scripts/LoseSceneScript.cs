using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseSceneScript : MonoBehaviour {

    GameObject continueButton;
    GameObject playAgainButton;
    GameObject menuButton;
    GameObject scoreText;
    GameObject highscoreText;

    // Use this for initialization
    void Start () {
        continueButton = GameObject.Find("ContinueButton");
        playAgainButton = GameObject.Find("PlayAgainButton");
        menuButton = GameObject.Find("MenuButton");
        scoreText = GameObject.Find("ScoreText");
        highscoreText = GameObject.Find("HighscoreText");

        scoreText.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("score");
        if (PlayerPrefs.GetInt("score") == PlayerPrefs.GetInt("highscore"))
        {
            highscoreText.GetComponent<Text>().text = "New Highscore!!!";
        }
        else
        {
            highscoreText.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("highscore");
        }

        menuButton.GetComponentInChildren<Text>().enabled = false;
        menuButton.GetComponent<Button>().enabled = false;
        menuButton.GetComponent<Button>().image.enabled = false;

        playAgainButton.GetComponentInChildren<Text>().enabled = false;
        playAgainButton.GetComponent<Button>().enabled = false;
        playAgainButton.GetComponent<Button>().image.enabled = false;
    }

    public void showButtons()
    {
        menuButton.GetComponentInChildren<Text>().enabled = true;
        menuButton.GetComponent<Button>().enabled = true;
        menuButton.GetComponent<Button>().image.enabled = true;

        playAgainButton.GetComponentInChildren<Text>().enabled = true;
        playAgainButton.GetComponent<Button>().enabled = true;
        playAgainButton.GetComponent<Button>().image.enabled = true;

        continueButton.GetComponentInChildren<Text>().enabled = false;
        continueButton.GetComponent<Button>().enabled = false;
        continueButton.GetComponent<Button>().image.enabled = false;
    }
}
