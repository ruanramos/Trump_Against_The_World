using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnnerScript : MonoBehaviour {

    public int level;
    private int numberOfEnemies;
    private float time;
    public bool shouldSpawn = false;
    public int score;


    public GameObject prefabFastEnemy;
    public GameObject prefabGuitarEnemy;
    public GameObject prefabMuslimWomanEnemy;
    public GameObject prefabAmericanMan;
    public GameObject prefabObama;
    public GameObject prefabKim;

    GameObject trump;
    GameObject gameController;

    private bool canStart;

    private void Awake()
    {
        time = 0;
        canStart = false;
    }

    // Use this for initialization
    void Start () {
        trump = GameObject.Find("Trump");
        gameController = GameObject.Find("GameController");
        StartCoroutine(gameStart());
        score = 0;
        level = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (!canStart && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            canStart = true;
            Destroy(GameObject.Find("StartText"));
            Destroy(GameObject.Find("PanelStart"));
        }
    }

    private void FixedUpdate()
    {
        if (canStart) time += Time.deltaTime;
        level = (score / 500) + 1;

        if (trump.GetComponent<TrumpScript>().putinPlaying || this.GetComponent<GameControllerScript>().shouldEnd)
        {
            shouldSpawn = false;
        }
        else
        {

            // time between spawns. I made this function to make the difficulty not exponencial

            if (time >= 0.8f - Mathf.Log(level, 10) / 3)
            {
                Debug.Log(0.8f - Mathf.Log(level, 10) / 3);
                shouldSpawn = true;
                time = 0;
            }

            GameObject levelText = GameObject.Find("LevelText");
            levelText.GetComponent<Text>().text = "Level " + level;

            GameObject scoreText = GameObject.Find("ScoreText");
            scoreText.GetComponent<Text>().text = "Score: " + score + "\nJobs Stolen: " + gameController.GetComponent<GameControllerScript>().jobsStolen + " / 10";
        }

        // calcula posição do spawn e a probabilidade de spawnar cada tipo de inimigo
        if (shouldSpawn) {
            float xPosition = Random.Range(-1.9f, 1.9f);
            float yPosition = Random.Range(5.5f, 9f);
            Vector3 position0 = new Vector3(xPosition, yPosition, 0);
            Vector3 position1 = new Vector3(xPosition, yPosition, -1);
            Vector3 position2 = new Vector3(xPosition, yPosition, -2);
            float enemyTypeNumber = Random.Range(0f, 1f);

            // aqui ele dá a porcentagem de cada tipo de inimigo dependendo do level
            if (level <= 2)
            {
                if (enemyTypeNumber >= 0.6)
                {
                    GameObject enemy = Instantiate(prefabMuslimWomanEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.1)
                {
                    GameObject enemy = Instantiate(prefabGuitarEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else
                {
                    GameObject enemy = Instantiate(prefabAmericanMan, position0, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
            }

            else if (level <= 4)
            {
                if (enemyTypeNumber >= 0.7)
                {
                    GameObject enemy = Instantiate(prefabFastEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.5)
                {
                    GameObject enemy = Instantiate(prefabMuslimWomanEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                
                else if (enemyTypeNumber >= 0.1)
                {
                    GameObject enemy = Instantiate(prefabGuitarEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else
                {
                    GameObject enemy = Instantiate(prefabAmericanMan, position0, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
            }

            else if (level <= 6)
            {
                if (enemyTypeNumber >= 0.7)
                {
                    GameObject enemy = Instantiate(prefabFastEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.6)
                {
                    GameObject enemy = Instantiate(prefabMuslimWomanEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.55)
                {
                    GameObject enemy = Instantiate(prefabObama, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.1)
                {
                    GameObject enemy = Instantiate(prefabGuitarEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else
                {
                    GameObject enemy = Instantiate(prefabAmericanMan, position0, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
            }

            else if (level <= 7)
            {
                if (enemyTypeNumber >= 0.65)
                {
                    GameObject enemy = Instantiate(prefabFastEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.6)
                {
                    GameObject enemy = Instantiate(prefabMuslimWomanEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.55)
                {
                    GameObject enemy = Instantiate(prefabKim, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.45)
                {
                    GameObject enemy = Instantiate(prefabObama, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.1)
                {
                    GameObject enemy = Instantiate(prefabGuitarEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else
                {
                    GameObject enemy = Instantiate(prefabAmericanMan, position0, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
            }
            else if (level <= 10)
            {
                if (enemyTypeNumber >= 0.65)
                {
                    GameObject enemy = Instantiate(prefabFastEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.63)
                {
                    GameObject enemy = Instantiate(prefabMuslimWomanEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.5)
                {
                    GameObject enemy = Instantiate(prefabKim, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.4)
                {
                    GameObject enemy = Instantiate(prefabObama, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.1)
                {
                    GameObject enemy = Instantiate(prefabGuitarEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else
                {
                    GameObject enemy = Instantiate(prefabAmericanMan, position0, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
            }
            else if (level <= 12)
            {
                if (enemyTypeNumber >= 0.55)
                {
                    GameObject enemy = Instantiate(prefabFastEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.53)
                {
                    GameObject enemy = Instantiate(prefabMuslimWomanEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.4)
                {
                    GameObject enemy = Instantiate(prefabKim, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.3)
                {
                    GameObject enemy = Instantiate(prefabObama, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.1)
                {
                    GameObject enemy = Instantiate(prefabGuitarEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else
                {
                    GameObject enemy = Instantiate(prefabAmericanMan, position0, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
            }
            else if (level <= 14)
            {
                if (enemyTypeNumber >= 0.6)
                {
                    GameObject enemy = Instantiate(prefabFastEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.58)
                {
                    GameObject enemy = Instantiate(prefabMuslimWomanEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.45)
                {
                    GameObject enemy = Instantiate(prefabKim, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.3)
                {
                    GameObject enemy = Instantiate(prefabObama, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.1)
                {
                    GameObject enemy = Instantiate(prefabGuitarEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else
                {
                    GameObject enemy = Instantiate(prefabAmericanMan, position0, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
            }
            else
            {
                if (enemyTypeNumber >= 0.6)
                {
                    GameObject enemy = Instantiate(prefabFastEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.58)
                {
                    GameObject enemy = Instantiate(prefabMuslimWomanEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.45)
                {
                    GameObject enemy = Instantiate(prefabKim, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.3)
                {
                    GameObject enemy = Instantiate(prefabObama, position2, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else if (enemyTypeNumber >= 0.1)
                {
                    GameObject enemy = Instantiate(prefabGuitarEnemy, position1, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
                else
                {
                    GameObject enemy = Instantiate(prefabAmericanMan, position0, transform.rotation) as GameObject;
                    shouldSpawn = false;
                }
            }
        }
    }

    IEnumerator gameStart()
    {
        canStart = false;
        GameObject startText = GameObject.Find("StartText");
        GameObject startPanel = GameObject.Find("PanelStart");
        startPanel.GetComponent<Image>().enabled = true;
        startText.GetComponent<Text>().text = "Now you have the job to protect your country, your people and your land from these bad guys over there that are trying to bring tragedy into America. Protect " +
            "the American jobs, do not let people be unemployed because of these bastards!!! They’re bringing drugs, they’re bringing crime, they’re rapists, and some, I assume, are good people... " +
            "Make America Great Again!!";
        yield return new WaitForSeconds(10);
        Destroy(startText.gameObject);
        Destroy(startPanel.gameObject);
        canStart = true;
    }
}
