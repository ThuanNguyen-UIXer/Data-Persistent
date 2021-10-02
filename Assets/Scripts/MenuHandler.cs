using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuHandler : MonoBehaviour
{
    public InputField inputName;
    public Text highScoreText;

    //Awake
    public void Awake()
    {
        GameManager.Instance.LoadData();
        ShowLoadData();
    }

    //StartGame
    public void StartGame()
    {
        SceneManager.LoadScene(1);

        if(inputName.text != GameManager.Instance.playerName)
        {
            InputName();
            GameManager.Instance.SaveData();
        }
    }

    //InputName
    public void InputName()
    {
        GameManager.Instance.playerName = inputName.text;
    }

    //ShowLoadData
    public void ShowLoadData()
    {
        highScoreText.text = "Best Score: " + GameManager.Instance.playerHighScore;
        inputName.text = GameManager.Instance.playerName;
    }

    //Quit
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

}
