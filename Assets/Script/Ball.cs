using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Ball that the player is controlling
public class Ball : MonoBehaviour {



    Rigidbody rigidbody;
    bool isColliding;

    //HUD stuff
    Text timeText;
    Text timeText2;
    Image[] collectibleImage;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        isColliding = false;

        //Find HUD

        //Collectible images
        collectibleImage = new Image[3];
        collectibleImage[0] = GameObject.Find("CollectibleImage").GetComponent<Image>();
        collectibleImage[1] = GameObject.Find("CollectibleImage2").GetComponent<Image>();
        collectibleImage[2] = GameObject.Find("CollectibleImage3").GetComponent<Image>();

        //Timer
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        timeText2 = GameObject.Find("TimeText2").GetComponent<Text>();

        //Find if a collectible was already collected
        if (GameManager.items[GameManager.levelId, 0]) showCollectible(0);
        if (GameManager.items[GameManager.levelId, 1]) showCollectible(1);
        if (GameManager.items[GameManager.levelId, 2]) showCollectible(2);

        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update () {
        //Die from the void
        if (transform.position.y < -10.0f) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        //Jump upon tapping the screen
        if ((Input.touchCount > 0 || Input.GetKey(KeyCode.Space)) && isColliding) rigidbody.AddForce(0.0f, 100.0f, 0.0f);
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

    //Show a collectible on the hud.
    public void showCollectible(int collectibleNo)
    {

    collectibleImage[collectibleNo].color = new Color(1.0f, 1.0f, 0.0f, 0.5f);

    }

    //Level timer
    public float time;
    public IEnumerator StartCountdown(float countdownValue = 0)
    {
        time = countdownValue;
        while (time < 999)
        {
            yield return new WaitForSeconds(0.1f);
            time += 0.1f;

            time = (float)System.Math.Round(time, 2);
            //Update actual display time
            timeText.text = time.ToString();
            timeText2.text = time.ToString();
        }
    }
}
