using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmericaScript : MonoBehaviour {

    GameObject gameController;
    GameObject trump;

    GameObject putinButton;
    GameObject wallButton;

    float collisionTime = 100000000000;

    public bool buttonsDisabled;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController");
        trump = GameObject.Find("Trump");

        putinButton = GameObject.Find("PutinButton");
        wallButton = GameObject.Find("WallButton");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Time.time - collisionTime >= 3)
        {
            buttonsDisabled = false;
            putinButton.GetComponent<Button>().interactable = true;
            wallButton.GetComponent<Button>().interactable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GuitarEnemy" || collision.tag == "FastEnemy" || collision.tag == "MuslimWomanEnemy")
        {
            trump.GetComponent<TrumpScript>().getMad = true;
            collision.GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(collision.gameObject);
            gameController.GetComponent<GameControllerScript>().jobsStolen++;
        }
        else if (collision.tag == "AmericanMan")
        {
            Destroy(collision.gameObject, 3);
            collision.GetComponent<AmericanMan>().velocity1 *= 2.5f;
        }
        else if (collision.tag == "Obama")
        {
            collisionTime = Time.time;
            buttonsDisabled = true;
            putinButton.GetComponent<Button>().interactable = false;
            wallButton.GetComponent<Button>().interactable = false;
            collision.GetComponent<SpriteRenderer>().sprite = collision.GetComponent<ObamaScript>().obamaSprites[1];
            if (!trump.GetComponent<TrumpScript>().putinPlaying)
            {
                collision.GetComponent<AudioSource>().Play();
            }
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<ObamaScript>().velocity *= 2.5f;
            Destroy(collision.gameObject, 3);
        }
        else if (collision.tag == "Kim")
        {
            collision.GetComponent<KimScript>().velocity *= 2.5f;
            collision.GetComponent<Collider2D>().enabled = false;

            GameObject[] fastEnemies = GameObject.FindGameObjectsWithTag("FastEnemy");
            GameObject[] guitarEnemies = GameObject.FindGameObjectsWithTag("GuitarEnemy");
            GameObject[] muslimWomanEnemies = GameObject.FindGameObjectsWithTag("MuslimWomanEnemy");
            GameObject[] americanMen = GameObject.FindGameObjectsWithTag("AmericanMan");
            GameObject[] obamas = GameObject.FindGameObjectsWithTag("Obama");

            for (int i = 0; i < fastEnemies.Length; i++)
            {
                fastEnemies[i].GetComponent<MexicanFastScript>().velocity *= 1.5f;
            }
            for (int i = 0; i < guitarEnemies.Length; i++)
            {
                guitarEnemies[i].GetComponent<MexicanGuitarScript>().velocity1 *= 1.5f;
            }

            for (int i = 0; i < muslimWomanEnemies.Length; i++)
            {
                muslimWomanEnemies[i].GetComponent<MuslimWomanScript>().velocity *= 1.5f;
            }

            for (int i = 0; i < americanMen.Length; i++)
            {
                americanMen[i].GetComponent<AmericanMan>().velocity1 *= 1.5f;
            }

            for (int i = 0; i < obamas.Length; i++)
            {
                obamas[i].GetComponent<ObamaScript>().velocity *= 1.5f;
            }

            Destroy(collision.gameObject, 3);
        }
    }
}
