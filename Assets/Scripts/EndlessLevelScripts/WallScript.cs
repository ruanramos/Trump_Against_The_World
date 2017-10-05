using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public int life;
    public Sprite wall3Life;
    public Sprite wall2Life;
    public Sprite wall1Life;
    public Sprite WallHeldByMouse;

    public bool wallPositioned;
    public bool shouldPlayQuoteAboutWall = false;

    // if changing, change on WallScript, ButtonsScript, GameControllerScript, TrumpScript
    //public int putinCost = 2000;
    //public int wallCost = 500;

    GameObject gameController;

    GameObject trump;

    // Use this for initialization
    void Start () {
        trump = GameObject.Find("Trump");
        life = 10;
        gameController = GameObject.Find("GameController");
        GetComponent<BoxCollider2D>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position;
        if ((Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)) && 
            !wallPositioned && gameController.GetComponent<GameControllerScript>().gold >= 500)
        {
            position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            position.z = 10;
            this.transform.position = position;
            
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !wallPositioned && transform.position.y > -3.0f)
        {
            life = 5;
            position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            position.z = 1;
            this.transform.position = position;
            GetComponent<BoxCollider2D>().enabled = true;
            wallPositioned = true;
            gameController.GetComponent<GameControllerScript>().gold -= gameController.GetComponent<GameControllerScript>().wallCost;
            shouldPlayQuoteAboutWall = true;
        }

        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !wallPositioned && transform.position.y < -2.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!wallPositioned)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        // set the sprite of the wall based on it's current life
        if (life == 6 || life == 5)
        {
            this.GetComponent<SpriteRenderer>().sprite = wall3Life;
        }
        else if (life == 4 || life == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = wall2Life;
        }
        else if (life == 2 || life == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = wall1Life;
        }
        else if (life <= 0)
        {
            Destroy(this.gameObject);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FastEnemy" || collision.gameObject.tag == "GuitarEnemy" || collision.gameObject.tag == "MuslimWomanEnemy")
        {
            Destroy(collision.gameObject);
            life--;
            if (collision.gameObject.tag == "FastEnemy")
            {
                gameController.GetComponent<GameControllerScript>().gold += 100;
                gameController.GetComponent<SpawnnerScript>().score += 100;
            }
            else if (collision.gameObject.tag == "GuitarEnemy")
            {
                gameController.GetComponent<GameControllerScript>().gold += 50;
                gameController.GetComponent<SpawnnerScript>().score += 50;
            }
            else if (collision.gameObject.tag == "MuslimWomanEnemy")
            {
                gameController.GetComponent<GameControllerScript>().gold += 25;
                gameController.GetComponent<SpawnnerScript>().score += 25;
            }
        }

        else if (collision.gameObject.tag == "Kim")
        {
            Destroy(this.gameObject);
            if (!collision.gameObject.GetComponent<AudioSource>().isPlaying)
            {
                collision.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    

}
