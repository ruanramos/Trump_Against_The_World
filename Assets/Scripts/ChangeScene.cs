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
        SceneManager.LoadScene(s);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    IEnumerator waitAudio(AudioSource a, string s)
    {
        this.transform.position = new Vector2(this.transform.position.x + 0.7f, this.transform.position.y);
        this.GetComponent<SpriteRenderer>().sprite = trump;
        GameObject.Find("Play").GetComponent<Button>().interactable = false;
        GameObject.Find("Quit").GetComponent<Button>().interactable = false;
        yield return new WaitUntil(() => !a.isPlaying);
        SceneManager.LoadScene(s);
    }
}
