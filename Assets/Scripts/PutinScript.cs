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

    // Use this for initialization
    void Start () {
        trump = GameObject.Find("Trump");
        putinText = GameObject.Find("PutinText");
        time = 0;
        lights = GameObject.Find("LIGHTS");
        this.GetComponent<SpriteRenderer>().sprite = putinDancing[0];
        lights.GetComponent<SpriteRenderer>().enabled = false;
        lights.GetComponent<SpriteRenderer>().color = Color.red;
        putinText.GetComponent<Text>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
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
