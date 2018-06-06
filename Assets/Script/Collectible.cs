using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    //3 Per level. The goal object will check what objects remain.
    //USE NAMES CAREFULLY.
    //Collectible0, Collectible 1 and Collectible2 will be the names the goal checks for.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerSphere")
        {
            //Update player hud

            Ball player = other.GetComponent<Ball>();

            if (gameObject.name == "Collectible0") player.showCollectible(0);
            else if (gameObject.name == "Collectible1") player.showCollectible(1);
            else if (gameObject.name == "Collectible2") player.showCollectible(2);


            //Destroy self
            Destroy(gameObject);
        }

    }
}
