using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    GameObject[] allObjects;
    bool paused;


    // Use this for initialization
    void Start () {

        Button button = GetComponent<Button>();
        button.onClick.AddListener(pause);


        paused = false;

        //Disable child buttons (pause menu)
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild(0).gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pause()
    {
        if (paused)
        {
            unPause();
            return;
        }

        Screen.sleepTimeout = SleepTimeout.SystemSetting;

        //Find all existing objects to disable them
        allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.tag != "Unpauseable") obj.SetActive(false);
            //Don't disable the following objects
            /* if (obj.name != "Game Manager" && obj.name != "Canvas" && obj.name != "PlayerFollower"
                 && obj.name != "Main Camera") obj.SetActive(false);*/
        }

        //Enable pause menu

        paused = true;

        //Disable child buttons
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }


        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void unPause()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        foreach (GameObject obj in allObjects)
        {
           obj.SetActive(true);

            //Make sure timer doesn't stop for good
            if (obj.name == "PlayerSphere") obj.GetComponent<Ball>().unPauseCountdown();

        }

        paused = false;

        //Disable pause menu
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild(0).gameObject.SetActive(true);

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
    }
}
