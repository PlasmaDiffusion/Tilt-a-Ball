using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script makes an object always be at the player position but not the rotation.
public class CameraController : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update () {
        if (player.activeSelf)
        transform.position = player.transform.position;
	}
}
