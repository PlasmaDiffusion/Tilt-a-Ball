using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelButton : MonoBehaviour {

    public int levelIndex;

	// Use this for initialization
	void Start () {

        //Colour blue if level was cleared
		if (GameManager.clears[levelIndex])
        {
            Text t = transform.Find("ColouredText").GetComponent<Text>();
            t.color = new Color(0.0f, 0.0f, 1.0f);

            //Show time text if beaten
            Transform timeTransform = transform.Find("TimeHolder");
            t = timeTransform.GetChild(0).GetComponent<Text>();
            t.text = GameManager.bestTimes[levelIndex].ToString();

            t = timeTransform.GetChild(1).GetComponent<Text>();
            t.text = GameManager.bestTimes[levelIndex].ToString();

            //Colour it blue if the best time was beaten
            if (GameManager.timeClears[levelIndex]) t.color = new Color (0.0f, 0.0f, 1.0f);
        }

        //Colour in images if collectibles were found
        for (int i = 0; i < 3; i ++)
        {
            if (GameManager.items[levelIndex, i])
            {
               Image image = transform.Find("CollectibleImage" + i.ToString()).GetComponent<Image>();
               image.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
            }
        }

        Button button = GetComponent<Button>();
        button.onClick.AddListener(enterLevel);
    }
	
    public void enterLevel()
    {
        GameManager.levelId = levelIndex;
        SceneManager.LoadScene(levelIndex + 1); //0 is the level select so offset the actual scene number
    }

	// Update is called once per frame
	void Update () {
		
	}
    
}
