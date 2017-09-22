using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimScript : MonoBehaviour {

    public float velocity = 2.5f;
    public Sprite kimSprite;

    GameObject gameController;
    GameObject trump;

    private int kimGold = 150;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        trump = GameObject.Find("Trump");

        GetComponent<SpriteRenderer>().sprite = kimSprite;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * velocity * Time.deltaTime);
    }

    void OnMouseDown()
    {
        GameObject.Find("Particle System").transform.position = this.transform.position;
        GameObject.Find("Particle System").GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject);
        trump.GetComponent<TrumpScript>().getHappy = true;
        gameController.GetComponent<GameControllerScript>().gold += kimGold;
        gameController.GetComponent<GameControllerScript>().kimsKilled++;
        gameController.GetComponent<SpawnnerScript>().score += kimGold;
    }
}
