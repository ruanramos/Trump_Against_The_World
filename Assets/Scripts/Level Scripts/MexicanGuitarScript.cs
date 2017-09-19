using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexicanGuitarScript : MonoBehaviour
{
    public float velocity1 = 2f;
    public Sprite guitarSprite;

    GameObject gameController1;
    GameObject trump1;

    private int guitarEnemyGold = 50;

    // Use this for initialization
    void Start()
    {
        gameController1 = GameObject.Find("GameController");
        trump1 = GameObject.Find("Trump");

        GetComponent<SpriteRenderer>().sprite = guitarSprite;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * velocity1 * Time.deltaTime);
    }

    void OnMouseDown()
    {
        Destroy(this.gameObject);
        trump1.GetComponent<TrumpScript>().getHappy = true;
        gameController1.GetComponent<GameControllerScript>().gold += guitarEnemyGold;
        gameController1.GetComponent<GameControllerScript>().mexicanGuitarKilled++;
        gameController1.GetComponent<SpawnnerScript>().score += guitarEnemyGold;

    }
}
