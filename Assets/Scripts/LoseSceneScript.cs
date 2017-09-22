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
    public GameObject finalText;

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

    private void Update()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
        }
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

        
        Destroy(GameObject.Find("trumpFree_05"));
        Destroy(GameObject.Find("LoseImage"));
        Destroy(GameObject.Find("Text"));
        Destroy(GameObject.Find("ScoreText"));
        Destroy(GameObject.Find("HighscoreText"));
        GameObject.Find("Backgroud").GetComponent<SpriteRenderer>().color = Color.black;
        finalText.GetComponent<Text>().text = "-Make Immigrants Already In Your Community Feel Welcome\n" +
        "- Sign Up To Help Refugees In Your Community\n" +
        "- Spread The Word About Immigrants' & Refugees' Rights\n" +
        "- Offer Your Legal Or Translation Skills\n" +
        "- Provide Necessities To Those in need\n" +
        "- Fund Organizations Helping Immigrants\n" +
        "- Be Human, help humans\n" +
        "- List of Organizations to help:\n\n" +
        "-->Unrwausa\n" +
        "-->Black Alliance for Just Immigration\n" +
        "-->Council on American - Islamic Relations\n" +
        "-->CUNY CLEAR\n" +
        "-->Families for Freedom\n" +
        "-->Immigrant Defense Project\n" +
        "-->Immigrant Legal Resource Center(ILRC)\n" +
        "-->International Rescue Committee\n" +
        "-->The International Refugee Assistance Project\n" +
        "-->Mariposas Sin Fronteras\n" +
        "-->MPower Change\n" +
        "-->National Immigration Law Center;\n";
    }
}
