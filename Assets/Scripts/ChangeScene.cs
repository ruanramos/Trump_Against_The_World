using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public AudioClip introAudio;
    public Sprite trump;

    private void Start()
    {

    }

    public void callSceneFromMenu (string sceneName)
    {
        this.GetComponent<AudioSource>().clip = introAudio;
        this.GetComponent<AudioSource>().loop = false;
        this.GetComponent<AudioSource>().Play();

        StartCoroutine(waitAudio(this.GetComponent<AudioSource>(), sceneName));
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void loadScene(string s)
    {
        if (SceneManager.GetActiveScene().name == "LoseScene")
        {
            GameObject audios = GameObject.Find("Audios");
            audios.GetComponent<AudioSource>().Stop();
        }
        else if (SceneManager.GetActiveScene().name == "PreGameScene")
        {
            GameObject audios = GameObject.Find("Background");
            audios.GetComponent<AudioSource>().Stop();
        }
        else if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            GameObject audios = GameObject.Find("Image1");
            audios.GetComponent<AudioSource>().Stop();
        }

        StartCoroutine(LoadAsync(s));
        
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    IEnumerator LoadAsync (string s)
    {
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

    IEnumerator waitAudio(AudioSource a, string s)
    {
        this.transform.position = new Vector2(this.transform.position.x + 0.7f, this.transform.position.y);
        this.GetComponent<SpriteRenderer>().sprite = trump;
        GameObject.Find("Play").GetComponent<Button>().interactable = false;
        GameObject.Find("Quit").GetComponent<Button>().interactable = false;
        yield return new WaitUntil(() => !a.isPlaying);

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
