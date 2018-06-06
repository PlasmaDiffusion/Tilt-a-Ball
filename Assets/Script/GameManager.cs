using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    public static bool[,] items;
    public static bool[] clears;
    public static bool[] timeClears;

    const int levelCount = 20;

    public static float[] bestTimes;

    public static int levelId = 0;

    static bool initialized = false;

    private void Awake()
    {
        if (initialized) return;

        Debug.Log("initializing clear flags");
        //Initialize clear flags
        items = new bool[levelCount, 3];
        clears = new bool[levelCount];
        timeClears = new bool[levelCount];
        bestTimes = new float[levelCount];

        for (int i = 0; i < levelCount; i++) bestTimes[i] = 15.0f;

        initialized = true;
    }

    // Use this for initialization
    void Start() {

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gameCompletion.dat", FileMode.Open);
        GameCompletion data = new GameCompletion();

        //Save data
        data.items = items;
        data.clears = clears;
        data.timeClears = timeClears;
        data.bestTimes = bestTimes;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            GameCompletion data = (GameCompletion)bf.Deserialize(file);

            file.Close();

            items = data.items;
            clears = data.clears;
            timeClears = data.timeClears;
            bestTimes = data.bestTimes;
        }
    }

    //Class for saving data
    [SerializeField]
    class GameCompletion
    {

       public bool[,] items;
       public bool[] clears;
       public bool[] timeClears;
        public float[] bestTimes;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
