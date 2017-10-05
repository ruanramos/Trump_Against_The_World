using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWallScript : MonoBehaviour {

    public GameObject prefabWall;
    GameObject gameController;
    Vector4 activeColor = new Vector4(1, 1, 1, 1);
    Vector4 nonActiveColor = new Vector4(1, 1, 1, 160/255f);

    GameObject america;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController");
        america = GameObject.Find("America");
    }

    // Update is called once per frame
    public void FixedUpdate () {

        if (!america.GetComponent<AmericaScript>().buttonsDisabled)
        {
            if (gameController.GetComponent<GameControllerScript>().gold >= 500)
            {
                this.GetComponent<SpriteRenderer>().color = activeColor;
            }
            else if (gameController.GetComponent<GameControllerScript>().gold < 500)
            {
                this.GetComponent<SpriteRenderer>().color = nonActiveColor;
            }
        }
        else
        {
            GameObject.Find("button wall").GetComponent<SpriteRenderer>().color = new Vector4(1, 60 / 255f, 60 / 255f, 1);
        }
	}

    private void OnMouseDown()
    {
        GameObject wall = Instantiate(prefabWall, Camera.main.ScreenToWorldPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position)), transform.rotation) as GameObject;
        wall.GetComponent<WallScript>().wallPositioned = false;
    }
}
