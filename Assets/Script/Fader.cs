using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Literally just makes something transparent so its less in the face of the camera when the player collides with this object.
public class Fader : MonoBehaviour {

    public GameObject[] objectsToFade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerSphere")
        {
            for (int i = objectsToFade.Length - 1; i >=0; i--)
            {

                Destroy(objectsToFade[i]);
                /*
                Renderer renderer;
                renderer = objectsToFade[i].GetComponent<MeshRenderer>();
                Color oldCol = renderer.material.color;

                renderer.material.color = oldCol * new Color(0.0f, 0.0f, 0.0f, 0.3f);
                renderer.render*/
            }
        }
    }
}
