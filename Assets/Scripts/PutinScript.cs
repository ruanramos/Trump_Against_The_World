using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutinScript : MonoBehaviour {

    public Sprite[] putinDancing;
    float time;
    int i = 0;

    GameObject trump;
    GameObject lights;
    GameObject putinText;
    GameObject audioController;

    // Use this for initialization
    void Start () {
        trump = GameObject.Find("Trump");
        putinText = GameObject.Find("PutinText");
        audioController = GameObject.Find("Audios");
        time = 0;
        lights = GameObject.Find("LIGHTS");
        this.GetComponent<SpriteRenderer>().sprite = putinDancing[0];
        lights.GetComponent<SpriteRenderer>().enabled = false;
        lights.GetComponent<SpriteRenderer>().color = Color.red;
        putinText.GetComponent<Text>().enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (trump.GetComponent<TrumpScript>().putinPlaying && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            trump.GetComponent<TrumpScript>().putinPlaying = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            lights.GetComponent<SpriteRenderer>().enabled = false;
            putinText.GetComponent<Text>().enabled = false;
            audioController.GetComponent<AudioSource>().Stop();
            GameObject.Find("PutinPanel").GetComponent<Image>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (trump.GetComponent<TrumpScript>().putinPlaying)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            putinText.GetComponent<Text>().enabled = true;
            StartCoroutine(dancingLights());
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            lights.GetComponent<SpriteRenderer>().enabled = false;
            putinText.GetComponent<Text>().enabled = false;
        }
        if (i % 3 == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = putinDancing[i / 3];
        }
        

        if (i < 60)
        {
            i ++;
        }
        else
        {
            i = 0;
        }
    }

    IEnumerator dancingLights()
    {
        lights.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        lights.GetComponent<SpriteRenderer>().enabled = false;
    }
}
