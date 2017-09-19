using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    Vector3 pos1;
    Vector3 pos2;
    float objectHeight = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            pos1 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 0.5f);
            pos1 = Camera.main.ScreenToWorldPoint(pos1);
            pos2 = pos1;

        }

        if (Input.GetMouseButton(0))
        {
            pos2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 0.5f);
            pos2 = Camera.main.ScreenToWorldPoint(pos2);

        }

        if (pos2 != pos1)
        {
            Vector3 v3 = pos2 - pos1;
            transform.position = pos1 + (v3) / 2.0f;
            float hack = v3.magnitude / objectHeight;
            transform.localScale = new Vector3(transform.localScale.x, hack, transform.localScale.z);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, v3);
        }
    }
}
