using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


//PlayerData class
public class PlayerData
{
    public string name;
    public int highScore;
}

//GameManager class
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int playerHighScore;




    //Awake
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //SaveData
    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.name = playerName;
        data.highScore = playerHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //LoadData
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerName = data.name;
            playerHighScore = data.highScore;
        }
    }


}
