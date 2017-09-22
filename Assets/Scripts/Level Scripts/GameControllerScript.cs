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
    private int maxJobsStolen = 10;

    int numberNeededToPlayQuote = 5;

    public float time = 0;

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
            StartCoroutine(LoadAsync("LoseScene"));
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
