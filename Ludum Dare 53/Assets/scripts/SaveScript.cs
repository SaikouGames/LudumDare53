using System.Collections.Generic;
using UnityEngine;

public class SaveScript: MonoBehaviour
{
    public static SaveScript Instance;

    public Data gameData = new Data();

    private string filePath;

    private void Awake()
    {
        Instance = this;
        filePath = Application.persistentDataPath + "/GameData.json";
    }

    private void Start()
    {
        // If the save file doesn't exist, we create it
        if (!System.IO.File.Exists(filePath))
        {
            ResetSave();
            SaveToJson();
        }
    }

    public Data GetGameData()
    {
        LoadFromJson();

        return gameData;
    }

    public void Save(int levelId_, int starsNumber_)
    {
        // Get the actual highest level the player has reached, and compare it to this level's ID
        LoadFromJson();

        if (levelId_ > gameData.maxLevel)
        {
            gameData.maxLevel = levelId_;
        }

        if (gameData.levelsStars[levelId_] > starsNumber_)
        {
            gameData.levelsStars[levelId_] = starsNumber_;
        }

        SaveToJson();
    }

    public void ResetSave()
    {
        gameData.maxLevel = 0;
        for (int i = 0; i < 4; i++)
        {
            gameData.levelsStars.Add(0);
        }
    }

    private void SaveToJson()
    {
        string data = JsonUtility.ToJson(gameData);

        System.IO.File.WriteAllText(filePath, data);

        //Debug.Log("*** Game saved ***");
    }

    private void LoadFromJson()
    {
        string data = System.IO.File.ReadAllText(filePath);

        gameData = JsonUtility.FromJson<Data>(data);

        //Debug.Log("*** Save loaded *** ");
    }
}

public class Data
{
    // The highest level's id reached by the player
    public int maxLevel;
    public List<int> levelsStars = new List<int>();
}
