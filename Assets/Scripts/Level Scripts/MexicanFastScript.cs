using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexicanFastScript : MonoBehaviour {

    public float velocity = 3.5f;
    public Sprite fastSprite;

    private int fastEnemyGold = 100;

    GameObject gameController;
    GameObject trump;
    

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController");
        trump = GameObject.Find("Trump");

        GetComponent<SpriteRenderer>().sprite = fastSprite;
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
        gameController.GetComponent<GameControllerScript>().gold += fastEnemyGold;
        gameController.GetComponent<GameControllerScript>().fastMexicansKilled ++;
        gameController.GetComponent<SpawnnerScript>().score += fastEnemyGold;
    }
}
