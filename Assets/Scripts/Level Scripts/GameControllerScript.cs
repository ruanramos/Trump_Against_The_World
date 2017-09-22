using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public int gold = 0;
    GameObject goldText;
    public int womamMuslimEnemyKilled = 0;
    public int mexicanGuitarKilled = 0;
    public int americanMenKilled = 0;
    public int fastMexicansKilled = 0;
    public int obamasKilled = 0;
    public int kimsKilled = 0;

    public int jobsStolen = 0;
    public int maxJobsStolen = 10;

    int numberNeededToPlayQuote = 5;

    public float time = 0;

    float timeToFinish = 0;

    GameObject audioController;

    bool shouldPlay = true;

    // if changing, change on WallScript, ButtonsScript, GameControllerScript, TrumpScript
    public int putinCost = 2000;
    public int wallCost = 500;

    // Use this for initialization
    void Start()
    {
        goldText = GameObject.Find("GoldText");
        audioController = GameObject.Find("Audios");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
        }

        time += Time.deltaTime;
        if (jobsStolen >= maxJobsStolen)
        {
            PlayerPrefs.SetInt("score", this.GetComponent<SpawnnerScript>().score);
            if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", this.GetComponent<SpawnnerScript>().score);
            }
            GameObject.Find("GameController").GetComponent<AudioSource>().volume -= 0.02f * Time.deltaTime;

            GameObject[] fastEnemies = GameObject.FindGameObjectsWithTag("FastEnemy");
            GameObject[] guitarEnemies = GameObject.FindGameObjectsWithTag("GuitarEnemy");
            GameObject[] muslimWomanEnemies = GameObject.FindGameObjectsWithTag("MuslimWomanEnemy");
            GameObject[] americanMen = GameObject.FindGameObjectsWithTag("AmericanMan");
            GameObject[] obamas = GameObject.FindGameObjectsWithTag("Obama");
            GameObject[] kims  = GameObject.FindGameObjectsWithTag("Kim");

            for (int i = 0; i < fastEnemies.Length; i++)
            {
                fastEnemies[i].GetComponent<MexicanFastScript>().velocity = .5f;
                fastEnemies[i].GetComponent<Collider2D>().enabled = false;
            }
            for (int i = 0; i < guitarEnemies.Length; i++)
            {
                guitarEnemies[i].GetComponent<MexicanGuitarScript>().velocity1 = .5f;
                guitarEnemies[i].GetComponent<Collider2D>().enabled = false;
            }

            for (int i = 0; i < muslimWomanEnemies.Length; i++)
            {
                muslimWomanEnemies[i].GetComponent<MuslimWomanScript>().velocity = .5f;
                muslimWomanEnemies[i].GetComponent<Collider2D>().enabled = false;
            }

            for (int i = 0; i < americanMen.Length; i++)
            {
                americanMen[i].GetComponent<AmericanMan>().velocity1 = .5f;
                americanMen[i].GetComponent<Collider2D>().enabled = false;
            }

            for (int i = 0; i < obamas.Length; i++)
            {
                obamas[i].GetComponent<ObamaScript>().velocity = .5f;
                obamas[i].GetComponent<Collider2D>().enabled = false;
            }
            for (int i = 0; i < obamas.Length; i++)
            {
                kims[i].GetComponent<KimScript>().velocity = .5f;
                kims[i].GetComponent<Collider2D>().enabled = false;
            }
            timeToFinish += Time.deltaTime;
            if (timeToFinish >= 3)
            {
                SceneManager.LoadScene("LoseScene");
            }
            //StartCoroutine(LoadAsync("LoseScene"));
        }

        if (gold < 0)
        {
            gold = 0;
        }

        goldText.GetComponent<Text>().text = "" + gold;

        // define if a general quote from trump should be played
        if (time >= 13 && !audioController.GetComponent<AudioSource>().isPlaying)
        {
            shouldPlay = true;
            time = 0;
        } else
        {
            shouldPlay = false;
        }
        if (shouldPlay)
        {
            int clipToPlay = Random.Range(0, 21);
            audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudiosScript>().trumpQuotesInGeneral[clipToPlay];
            audioController.GetComponent<AudioSource>().Play();
            shouldPlay = false;
        }
    }

    
    IEnumerator LoadAsync(string s)
    {
        GameObject audios = GameObject.Find("Audios");
        GameObject controller = GameObject.Find("GameController");
        audios.GetComponent<AudioSource>().Stop();
        controller.GetComponent<AudioSource>().Stop();

        GameObject loadingScreen = GameObject.Find("LoadingScreen");
        Slider slider = GameObject.Find("Slider").GetComponent<Slider>();
        GameObject backgroundSlider = GameObject.Find("BackgroundSlider");
        GameObject fill = GameObject.Find("Fill");
        GameObject lisa = GameObject.Find("Lisa");
        GameObject CptAmerica = GameObject.Find("CptAmerica");

        lisa.GetComponent<Image>().enabled = true;
        CptAmerica.GetComponent<Image>().enabled = true;
        loadingScreen.GetComponent<Image>().enabled = true;
        slider.GetComponent<Slider>().enabled = true;
        fill.GetComponent<Image>().enabled = true;
        backgroundSlider.GetComponent<Image>().enabled = true;

        AsyncOperation operation = SceneManager.LoadSceneAsync(s);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }
    
}
