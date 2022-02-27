using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public Text highscoreText;
    public string PlayerName;
    public string Username;
    public int Highscore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);
        LoadData();
        SetHighScore();

    }

    [System.Serializable]
    class SaveHighScore
    {
        public string playerName;
        public int highscore;
    }

    public void SaveData()
    {
        SaveHighScore data = new SaveHighScore();

        data.playerName = PlayerName;
        data.highscore = Highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveHighScore data = JsonUtility.FromJson<SaveHighScore>(json);

            PlayerName = data.playerName;
            Highscore = data.highscore;
        }
    }

    public void SetHighScore()
    {
        highscoreText.text = "Best Score: " + PlayerName + " : " + Highscore;
    }
}
