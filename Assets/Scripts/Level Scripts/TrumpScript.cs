using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrumpScript : MonoBehaviour {

    public Sprite madTrump;
    public Sprite happyTrump;
    public Sprite confidentTrump;

    public bool getMad = false;
    public bool getHappy = false;

    public GameObject prefabWall;
    GameObject gameController;
    GameObject audioController;

    GameObject putinPanel;

    public bool putinPlaying = false;

    float time = 0;
    float lenghtAudioPutin;

    // if changing, change on WallScript, ButtonsScript, GameControllerScript, TrumpScript
    //public int putinCost = 2000;
    //public int wallCost = 500;


    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = confidentTrump;
        gameController = GameObject.Find("GameController");
        audioController = GameObject.Find("Audios");
        lenghtAudioPutin = audioController.GetComponent<AudiosScript>().trumpQuotesAboutPutin[0].length;
        putinPanel = GameObject.Find("PutinPanel");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (getHappy)
        {
            StartCoroutine(changingSprites(happyTrump));
            getHappy = false;
        }
        else if (getMad)
        {
            StartCoroutine(changingSprites(madTrump));
            getMad = false;
        }

        if (!putinPlaying)
        {
            gameController.GetComponent<AudioSource>().volume = 0.054f;
            time = 0;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = happyTrump;
            time += Time.deltaTime;
            if (time > lenghtAudioPutin + 0.5f)
            {
                putinPlaying = false;
                putinPanel.GetComponent<Image>().enabled = false;
            }
        }
    }

    IEnumerator changingSprites(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        yield return new WaitForSeconds(1.5f);
        GetComponent<SpriteRenderer>().sprite = confidentTrump;
    }

    public void instantiateWall()
    {
        
        bool shouldInstantiateWall = true;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach(GameObject w in walls)
        {
            if (!w.GetComponent<WallScript>().wallPositioned)
            {
                shouldInstantiateWall = false;
            }
        }
        if (shouldInstantiateWall && gameController.GetComponent<GameControllerScript>().gold >= gameController.GetComponent<GameControllerScript>().wallCost)
        {
            GameObject wall = Instantiate(prefabWall, Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation) as GameObject;
        }
    }

    public void putinAttack()
    {
        GameObject[] fastEnemies = GameObject.FindGameObjectsWithTag("FastEnemy");
        GameObject[] guitarEnemies = GameObject.FindGameObjectsWithTag("GuitarEnemy");
        GameObject[] muslimWomanEnemies = GameObject.FindGameObjectsWithTag("MuslimWomanEnemy");
        GameObject[] kims = GameObject.FindGameObjectsWithTag("Kim");

        if (!putinPlaying)
        {
            
            audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudiosScript>().trumpQuotesAboutPutin[0];
            
            audioController.GetComponent<AudioSource>().Play();
            putinPanel.GetComponent<Image>().enabled = true;
            putinPlaying = true;
            gameController.GetComponent<AudioSource>().volume = 0;
        }
        
        for (int i = 0; i < fastEnemies.Length; i++)
        {
            Destroy(fastEnemies[i]);
            gameController.GetComponent<GameControllerScript>().fastMexicansKilled++;
        }
        for (int i = 0; i < guitarEnemies.Length; i++)
        {
            Destroy(guitarEnemies[i]);
            gameController.GetComponent<GameControllerScript>().mexicanGuitarKilled++;
        }

        for (int i = 0; i < muslimWomanEnemies.Length; i++)
        {
            Destroy(muslimWomanEnemies[i]);
            gameController.GetComponent<GameControllerScript>().womamMuslimEnemyKilled++;
        }

        for (int i = 0; i < kims.Length; i++)
        {
            Destroy(kims[i]);
            gameController.GetComponent<GameControllerScript>().kimsKilled++;
        }

        gameController.GetComponent<GameControllerScript>().gold -= gameController.GetComponent<GameControllerScript>().putinCost;

    }
}
