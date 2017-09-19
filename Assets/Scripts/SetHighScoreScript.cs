using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resetHighscore()
    {
        PlayerPrefs.SetInt("highscore", 0);
        Destroy(GameObject.Find("ResetHighscoreButton"));
    }
}
