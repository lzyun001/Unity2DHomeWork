using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [Header("下一個關卡的名稱")]
    public string NextSceneName;
    public int LevelID;
    public Text Leveltext;
    [Header("設定每個關卡最高的分數")]
    public float SetHeightScore;
    string SaveHeightScore = "SaveHeightScore";
    string SaveLevelID = "SaveLevelID";
    static public int OpenLevelID = 1;
    public GameObject[] LevelButton;

    private void Start()
    {
        if (Application.loadedLevelName == "Level" && GetComponentInChildren<Text>() != null)
        {
            Leveltext = GetComponentInChildren<Text>();
            LevelID = int.Parse(Leveltext.text);
        }
        LevelButton = GameObject.FindGameObjectsWithTag("LevelButton");

        for (int i = 0; i < OpenLevelID-1; i++)
        {
            LevelButton[i].GetComponent<Button>().interactable = true;
        }

    }
         
    public void NextScene()
    {
        if (NextSceneName == "Movie")
        {
            PlayerPrefs.SetFloat(SaveLevelID, LevelID);
            PlayerPrefs.SetFloat(SaveHeightScore + LevelID, SetHeightScore);
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = false;
        }
        if(NextSceneName == "Game")
        {
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = true;
        }

        Application.LoadLevel(NextSceneName);
    }
}
