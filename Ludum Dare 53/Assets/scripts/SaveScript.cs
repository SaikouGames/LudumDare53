using UnityEngine;

public class SaveScript: MonoBehaviour
{
    public static SaveScript Instance;
    public Data gameData = new Data();

    private void Awake()
    {
        Instance = this;
    }
    public void Save(int levelId_, int starsNumber_)
    {
        gameData.level = levelId_;
        gameData.stars = starsNumber_;

        SaveToJson();
    }

    public Data GetGameData()
    {
        LoadFromJson();

        return gameData;
    }

    private void SaveToJson()
    {
        string data = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + "/GameData.json";

        Debug.Log(filePath);

        System.IO.File.WriteAllText(filePath, data);

        Debug.Log("*** Game saved ***");
    }
    private void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/GameData.json";
        string data = System.IO.File.ReadAllText(filePath);

        gameData = JsonUtility.FromJson<Data>(data);

        Debug.Log("*** Save loaded *** ");
    }
}

public class Data
{
    public int level;
    public int stars;
}
