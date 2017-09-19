using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmericanMan : MonoBehaviour {

    public float velocity1 = 2.5f;
    public Sprite americanMan;

    GameObject gameController1;
    GameObject trump1;

    private int punishment = 300;

    // Use this for initialization
    void Start () {
        gameController1 = GameObject.Find("GameController");
        trump1 = GameObject.Find("Trump");

        GetComponent<SpriteRenderer>().sprite = americanMan;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.down * velocity1 * Time.deltaTime);
    }

    void OnMouseDown()
    {
        Destroy(this.gameObject);
        trump1.GetComponent<TrumpScript>().getMad = true;
        gameController1.GetComponent<GameControllerScript>().gold -= punishment;
        gameController1.GetComponent<GameControllerScript>().americanMenKilled++;
        gameController1.GetComponent<SpawnnerScript>().score -= punishment;
    }
}
