using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour {

    GameObject tutorialText;

    public string newText;

	// Use this for initialization
	void Start () {
        tutorialText = GameObject.Find("TutorialPanel");
	}
	
    //Change the tutorial text to whatever, or remove it.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerSphere")
        {
            tutorialText.transform.GetChild(0).GetComponent<Text>().text = newText;
            if (newText == "") tutorialText.SetActive(false);
            else if (!gameObject.activeSelf) tutorialText.SetActive(true);
        }
    }
}
