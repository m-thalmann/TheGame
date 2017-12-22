using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {
    public GameObject cam;
    public GameObject obj;
    public int offset = 2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cam.transform.position = obj.transform.position + new Vector3(0, offset, -offset);
    }
}
