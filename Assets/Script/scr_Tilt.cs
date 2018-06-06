using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Tilt : MonoBehaviour {

    private float startRotX;
    private float startRotZ;
    public float rotLimit = 40.0f;
    public float rotSpeed = 4.0f;

    //Lerp rotation variables
    private float aimRotX;
    private float aimRotZ;
    private float lerpTime;

    //Variables for last given acceleration/phone rotation
    private float lastAccelX;
    private float lastAccelY;


    private bool computerDebug = true;

    // Use this for initialization
    void Start () {
        //Get starting rotations to know limit later.
        startRotX = transform.rotation.x;
        startRotZ = transform.rotation.z;

        //Vars for sensitivety
        lastAccelX = 0.0f;
        lastAccelY = 0.0f;

        //Lerp variables
        aimRotX = 0.0f;
        aimRotZ = 0.0f;
        lerpTime = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Input.acceleration.x * Time.deltaTime, 0, -Input.acceleration.z * Time.deltaTime);
        //transform.Rotate(Input.acceleration.x * Time.deltaTime * rotSpeed, 0, Input.acceleration.y * Time.deltaTime * rotSpeed);

        if (lerpTime < 1.0f) lerpTime += Time.deltaTime * 3.0f;

       
        //Lerp to new rotation
        transform.localRotation = new Quaternion(Mathf.Lerp(transform.localRotation.x, aimRotX, lerpTime), 0.0f,
                 Mathf.Lerp(transform.localRotation.z, aimRotZ, lerpTime), 1.0f);


        //See if the rotation changed
        if (accelChanged())
        {
            lerpTime = 0.0f;

            if (!computerDebug)
            { 
            aimRotX = Input.acceleration.x;
            aimRotZ = Input.acceleration.y + 0.5f;
            }
        }

        lastAccelX = Input.acceleration.x;
        lastAccelY = Input.acceleration.y;

        //Limit rotations based on the rotation limit.
        /*if (transform.rotation.x > startRotX + rotLimit)
            transform.rotation = new Quaternion(startRotX + rotLimit, transform.rotation.y, transform.rotation.z, 1.0f);
        if (transform.rotation.x < startRotX - rotLimit)
            transform.rotation = new Quaternion(startRotX - rotLimit, transform.rotation.y, transform.rotation.z, 1.0f);

        if (transform.rotation.z > startRotZ + rotLimit)
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, startRotZ + rotLimit, 1.0f);
        if (transform.rotation.z < startRotZ - rotLimit)
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, startRotZ - rotLimit, 1.0f);*/
    }

    //Return true only if acceleration changed significantly
    bool accelChanged()
    {
        if (computerDebug)
        {
            keyboard();
            return true;
        }

        float sensitivity = 0.025f;

        if ((Input.acceleration.x >= lastAccelX + sensitivity) || (Input.acceleration.x < lastAccelX - sensitivity))
        {
            return true;
        }

        if ((Input.acceleration.y >= lastAccelY + sensitivity) || (Input.acceleration.y < lastAccelY - sensitivity))
        {
            return true;
        }

        return false;
    }

    void keyboard()
    {
        if (Input.GetKey(KeyCode.D)) aimRotX += 0.05f;
        if (Input.GetKey(KeyCode.A)) aimRotX += -0.05f;

        if (Input.GetKey(KeyCode.W)) aimRotZ += 0.05f;
        if (Input.GetKey(KeyCode.S)) aimRotZ += -0.05f;
    }

    //Draw some debug stuff
    void OnGUI()
    {
        GUI.Label(new Rect(130, 0, 120, 100), Input.acceleration.x.ToString());
        GUI.Label(new Rect(260, 0, 120, 100), Input.acceleration.y.ToString());

        GUI.Label(new Rect(460, 0, 120, 100), lerpTime.ToString());
    }
}
