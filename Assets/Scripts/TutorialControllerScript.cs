using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialControllerScript : MonoBehaviour {

    GameObject nextButton;
    GameObject backButton;
    GameObject menuButton;
    GameObject cameraMain;
    Transform kimPosition;

    // Use this for initialization
    void Start () {
        nextButton = GameObject.Find("BotãoNext");
        backButton = GameObject.Find("BotãoBack");
        menuButton = GameObject.Find("BotãoMenu");
        cameraMain = GameObject.Find("Main Camera");
        kimPosition = GameObject.Find("Kim").transform;
    }

    private void FixedUpdate()
    {

        if (Camera.main.transform.position.x == 50)
        {
            kimPosition.transform.position += Vector3.down / 8;
            if (kimPosition.position.y < -4.7f)
            {
                kimPosition.transform.position = new Vector3(kimPosition.transform.position.x, 5.15f, kimPosition.transform.position.z);
            }
        }
        else
        {
            kimPosition.transform.position = new Vector3(kimPosition.transform.position.x, 5.15f, kimPosition.transform.position.z);
        }
        if (Screen.fullScreen)
        {
            Screen.SetResolution(Screen.width, Screen.height, true);
        }

        if (cameraMain.GetComponent<TutorialCameraScript>().position == 0)
        {
            backButton.GetComponent<Button>().enabled = false;
            backButton.GetComponent<Button>().image.enabled = false;
            backButton.GetComponentInChildren<Text>().enabled = false;

            menuButton.GetComponentInChildren<Text>().enabled = true;
            menuButton.GetComponent<Button>().enabled = true;
            menuButton.GetComponent<Button>().image.enabled = true;
            menuButton.transform.position = backButton.transform.position;
        }
        else if (cameraMain.GetComponent<TutorialCameraScript>().position < 7)
        {
            backButton.GetComponent<Button>().enabled = true;
            backButton.GetComponent<Button>().image.enabled = true;
            backButton.GetComponentInChildren<Text>().enabled = true;

            menuButton.GetComponentInChildren<Text>().enabled = false;
            menuButton.GetComponent<Button>().enabled = false;
            menuButton.GetComponent<Button>().image.enabled = false;

            nextButton.GetComponent<Button>().enabled = true;
            nextButton.GetComponent<Button>().image.enabled = true;
            nextButton.GetComponentInChildren<Text>().enabled = true;
        }
        else
        {
            backButton.GetComponent<Button>().enabled = true;
            backButton.GetComponent<Button>().image.enabled = true;
            backButton.GetComponentInChildren<Text>().enabled = true;

            menuButton.GetComponentInChildren<Text>().enabled = true;
            menuButton.GetComponent<Button>().enabled = true;
            menuButton.GetComponent<Button>().image.enabled = true;
            menuButton.transform.position = nextButton.transform.position;

            nextButton.GetComponent<Button>().enabled = false;
            nextButton.GetComponent<Button>().image.enabled = false;
            nextButton.GetComponentInChildren<Text>().enabled = false;
        }
    }
}
