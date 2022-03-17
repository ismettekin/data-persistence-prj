using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
   
    public string c_playerName;
    public int c_score;

    public string highScorePlayerName;
    public int highScore;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;

    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();

        data.highScorePlayerName = highScorePlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);

    }

    public void LoadHighScore()
    {
        string dataPath = Application.persistentDataPath + "savefile.json";

        if(File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScore = data.highScore;
        }

    }
}

