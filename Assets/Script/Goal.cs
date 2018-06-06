using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour {

    BoxCollider boxCollider;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerSphere")
        {
            GameManager.clears[GameManager.levelId] = true;

            //Optional collectibles are collected if they don't exist anymore
            if (!GameObject.Find("Collectible0")) GameManager.items[GameManager.levelId, 0] = true;
            if (!GameObject.Find("Collectible1")) GameManager.items[GameManager.levelId, 1] = true;
            if (!GameObject.Find("Collectible2")) GameManager.items[GameManager.levelId, 2] = true;
           
            //New time record
            float currentTime = collision.gameObject.GetComponent<Ball>().time;
            if (GameManager.bestTimes[GameManager.levelId] > currentTime)
            {
                GameManager.timeClears[GameManager.levelId] = true;
                GameManager.bestTimes[GameManager.levelId] = currentTime;
            }


            //Back to level select
            SceneManager.LoadScene(0);
        }
    }
}
