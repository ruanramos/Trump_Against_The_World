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

    public float putinEnteringTime;
    public float delayPutin = 1.5f;

    // if changing, change on WallScript, ButtonsScript, GameControllerScript, TrumpScript
    //public int putinCost = 2500;
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

        // make background music play if putin not playing or game not ended
        if (!putinPlaying && gameController.GetComponent<GameControllerScript>().jobsStolen < gameController.GetComponent<GameControllerScript>().maxJobsStolen)
        {
            gameController.GetComponent<AudioSource>().volume = 0.054f;
            time = 0;
        }

        else if (putinPlaying)
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

    public void putinAttack()
    {
        GameObject[] fastEnemies = GameObject.FindGameObjectsWithTag("FastEnemy");
        GameObject[] guitarEnemies = GameObject.FindGameObjectsWithTag("GuitarEnemy");
        GameObject[] muslimWomanEnemies = GameObject.FindGameObjectsWithTag("MuslimWomanEnemy");
        GameObject[] kims = GameObject.FindGameObjectsWithTag("Kim");
        GameObject[] obamas = GameObject.FindGameObjectsWithTag("Obama");

        if (!putinPlaying)
        {
            
            audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudiosScript>().trumpQuotesAboutPutin[0];
            
            audioController.GetComponent<AudioSource>().Play();
            putinPanel.GetComponent<Image>().enabled = true;
            putinPlaying = true;
            putinEnteringTime = Time.time;
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

        for (int i = 0; i < obamas.Length; i++)
        {
            Destroy(obamas[i]);
            gameController.GetComponent<GameControllerScript>().obamasKilled++;
        }

        gameController.GetComponent<GameControllerScript>().gold -= gameController.GetComponent<GameControllerScript>().putinCost;

    }
}
