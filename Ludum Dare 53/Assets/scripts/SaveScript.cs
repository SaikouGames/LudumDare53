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

        gameData.levelsData[levelId_].stars = starsNumber_;

        SaveToJson();
    }

    public void ResetSave()
    {
        gameData.maxLevel = 0;
        for (int i = 0; i < gameData.levelsData.Count; i++)
        {
            gameData.levelsData[i].levelId = i;
            gameData.levelsData[i].stars = 0;
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
    public List<LevelData> levelsData = new List<LevelData>();
}

public class LevelData
{
    // should be private setter
    public int levelId;
    public int stars;
}
