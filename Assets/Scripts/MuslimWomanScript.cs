using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuslimWomanScript : MonoBehaviour
{
    public float velocity = 2f;
    public Sprite muslimWomanSprite;

    GameObject gameController;
    GameObject trump;

    private int muslimWomanGold = 25;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        trump = GameObject.Find("Trump");

        GetComponent<SpriteRenderer>().sprite = muslimWomanSprite;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * velocity * Time.deltaTime);
    }

    void OnMouseDown()
    {
        Destroy(this.gameObject);
        trump.GetComponent<TrumpScript>().getHappy = true;
        gameController.GetComponent<GameControllerScript>().gold += muslimWomanGold;
        gameController.GetComponent<GameControllerScript>().womamMuslimEnemyKilled++;
        gameController.GetComponent<SpawnnerScript>().score += muslimWomanGold;
    }
}
