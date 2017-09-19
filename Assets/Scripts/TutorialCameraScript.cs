using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCameraScript : MonoBehaviour {
    bool goRight = false;
    bool goLeft = false;

    public float[] positions = { 0, 10, 20, 30, 40, 50, 60, 70 };
    static float t = 0.0f;
    public int position = 0;

    GameObject nextButton;
    GameObject backButton;
    GameObject menuButton;

    private void Start()
    {
        nextButton = GameObject.Find("BotãoNext");
        backButton = GameObject.Find("BotãoBack");
        menuButton = GameObject.Find("BotãoMenu");
    }

    private void Update()
    {
        if (goRight || goLeft)
        {
            nextButton.GetComponent<Button>().interactable = false;
            backButton.GetComponent<Button>().interactable = false;
            menuButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            nextButton.GetComponent<Button>().interactable = true;
            backButton.GetComponent<Button>().interactable = true;
            menuButton.GetComponent<Button>().interactable = true;
        }

        if (goRight)
        {
            if (position == 6)
            {
                transform.position = new Vector3(Mathf.Lerp(60, 70, t), transform.position.y, transform.position.z);
                if (transform.position.x == 70)
                {
                    goRight = false;
                    position++;
                    t = 0.0f;
                }
            }
            else
            {
                transform.position = new Vector3(Mathf.Lerp(positions[position], positions[position + 1], t), transform.position.y, transform.position.z);
                if (transform.position.x == positions[position + 1])
                {
                    goRight = false;
                    position++;
                    t = 0.0f;
                }
            }
        }
        else if (goLeft)
        {
            if (position == 7)
            {
                transform.position = new Vector3(Mathf.Lerp(70, 60, t), transform.position.y, transform.position.z);
                if (transform.position.x == 60)
                {
                    goLeft = false;
                    position--;
                    t = 0.0f;
                }
            }
            else
            {
                transform.position = new Vector3(Mathf.Lerp(positions[position], positions[position - 1], t), transform.position.y, transform.position.z);
                if (transform.position.x == positions[position - 1])
                {
                    goLeft = false;
                    position--;
                    t = 0.0f;
                }
            }
        }

        t += 2.5f * Time.deltaTime;
    }

    public void ChangeNextImage()
    {
        goRight = true;
        t = 0.0f;
    }

    public void ChangeLastImage()
    {
        goLeft = true;
        t = 0.0f;
    }
    
}