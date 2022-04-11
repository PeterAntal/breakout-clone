using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    //Current Player Name
    public string CurrentPlayerName;

    public string TopPlayerName;
    public int HighestScore;

    private PersistenceManager instance;

    public PersistenceManager GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("This instance isn't ready. Make sure it's available in the scene.");
        }
        return instance;
    }

    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighestScore = HighestScore;
        data.TopPlayerName = TopPlayerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(GetHighScorePath(), json);
    }

    public void LoadHighScore()
    {
        var path = GetHighScorePath();
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighestScore = data.HighestScore;
            TopPlayerName = data.TopPlayerName;
        }
    }

    private string GetHighScorePath()
    {
        return Application.persistentDataPath + "/highScore.json";
    }

    [System.Serializable]
    class SaveData
    {
        public string TopPlayerName;
        public int HighestScore;
    }
}
