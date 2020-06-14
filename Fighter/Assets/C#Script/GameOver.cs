using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string SaveScore = "SaveScore";
    public Text ScoreText;
    string SaveHeightScore = "SaveHeightScore";
    string SaveLevelID = "SaveLevelID";
    public Text HeightScoreText;
    [Header("重新遊戲的按鈕")]
    public Button RegameButton;
    [Header("下一關的按鈕")]
    public Button NextButtton;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score:" + PlayerPrefs.GetFloat(SaveScore);
        HeightScoreText.text = "Height Score:" + PlayerPrefs.GetFloat(SaveHeightScore + PlayerPrefs.GetFloat(SaveLevelID));
        if (PlayerPrefs.GetFloat(SaveHeightScore + PlayerPrefs.GetFloat(SaveLevelID)) > PlayerPrefs.GetFloat(SaveScore))
        {
            NextButtton.interactable = false;
        }
        else
        {
            NextButtton.interactable = true;
        }
        Cursor.visible = true;
    }
    public void NextGame()
    {
        if (PlayerPrefs.GetFloat(SaveLevelID) >= Level.OpenLevelID)
        Level.OpenLevelID++;
        Application.LoadLevel("Level");
    }
    public void ReGame()
    {
        Application.LoadLevel("Game");
    }
    public void Menu()
    {
        Application.LoadLevel("Menu");
        
    }

}
