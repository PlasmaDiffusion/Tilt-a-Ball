using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The farther from the player starting y, the darker the colour will be to show depth
public class DarkenFartherDown : MonoBehaviour {


    GameObject player;

    // Use this for initialization
    void Start() {


      player = GameObject.Find("PlayerSphere");


        changeColor(gameObject);

        //Change children too
        for (int i = 0; i < transform.childCount; i++)
        {
            changeColor(transform.GetChild(i).gameObject);
        }

    }

    void changeColor(GameObject obj)
    {

        Renderer renderer;

        renderer = obj.GetComponent<MeshRenderer>();
        Color oldCol = renderer.material.color;


        renderer.material.color = oldCol * (transform.position.y / player.transform.position.y);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
