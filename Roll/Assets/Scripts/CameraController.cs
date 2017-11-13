using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset; 

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	//Late Update is called after all Update() methods are processed
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}//Updates the Camera after the player has moved. 
}
