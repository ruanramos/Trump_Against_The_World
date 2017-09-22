using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSceneAudioScript : MonoBehaviour {

    public AudioClip[] audios;
	
    // Use this for initialization
	void Awake () {
		
	}

    private void Start()
    {
        if (PlayerPrefs.GetInt("highscore") == PlayerPrefs.GetInt("score"))
        {
            this.GetComponent<AudioSource>().clip = audios[0];
            this.GetComponent<AudioSource>().Play();
        }
        else if (PlayerPrefs.GetInt("highscore") > PlayerPrefs.GetInt("score"))
        {
            this.GetComponent<AudioSource>().clip = audios[1];
            this.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
