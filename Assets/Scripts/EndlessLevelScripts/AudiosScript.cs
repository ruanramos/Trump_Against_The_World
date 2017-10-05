using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosScript : MonoBehaviour {
    
    public AudioClip[] trumpQuotesAboutWall;
    [Space]
    public AudioClip[] trumpQuotesAboutPutin;
    [Space]
    public AudioClip[] trumpQuotesInGeneral;

    GameObject gameController;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i].GetComponent<WallScript>().shouldPlayQuoteAboutWall && !this.GetComponent<AudioSource>().isPlaying)
            {
                int clipToPlay = Random.Range(0, 12);
                this.GetComponent<AudioSource>().clip = trumpQuotesAboutWall[clipToPlay];
                this.GetComponent<AudioSource>().Play();
                walls[i].GetComponent<WallScript>().shouldPlayQuoteAboutWall = false;
            }
            else if (walls[i].GetComponent<WallScript>().shouldPlayQuoteAboutWall && this.GetComponent<AudioSource>().isPlaying)
            {
                walls[i].GetComponent<WallScript>().shouldPlayQuoteAboutWall = false;
            }
        }
    }
}
