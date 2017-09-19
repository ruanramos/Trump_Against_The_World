using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObamaScript : MonoBehaviour {

    public float velocity = 3f;
    public Sprite[] obamaSprites;

    GameObject gameController;
    GameObject trump;

    public AudioClip saberSound;

    public bool buttonsDisabled = false;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        trump = GameObject.Find("Trump");

        GetComponent<SpriteRenderer>().sprite = obamaSprites[0];
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * velocity * Time.deltaTime);
    }

    void OnMouseDown()
    {
        trump.GetComponent<TrumpScript>().getHappy = true;
        Destroy(this.gameObject);
        gameController.GetComponent<GameControllerScript>().obamasKilled++;
    }

}
