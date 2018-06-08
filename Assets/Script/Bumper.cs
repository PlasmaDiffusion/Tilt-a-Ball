using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    private bool scalingUp;
    private bool scalingDown;
    private const float scaleMax = 0.45f;
    private Vector3 scaleMinimum;

	// Use this for initialization
	void Start () {
        scaleMinimum = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
        //Upscale upon colliding
        if (scalingUp)
        {

            transform.localScale = transform.localScale * (1 + Time.deltaTime);
            if (transform.localScale.magnitude > scaleMax) //Scale up
            {
                scalingDown = true;
                scalingUp = false;
            }
        }
        if (scalingDown) //Scale down until too small
        {
            transform.localScale = transform.localScale * (1 - Time.deltaTime);
            if (transform.localScale.x < scaleMinimum.x)
            {
                    transform.localScale = scaleMinimum;
                    scalingDown = false;
            }
        }
        
	}

    //Bounce
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "PlayerSphere")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = -rb.velocity;
            rb.velocity += new Vector3(0.0f, 10.0f, 0.0f);
            scalingUp = true;
        }
        
    }
}
