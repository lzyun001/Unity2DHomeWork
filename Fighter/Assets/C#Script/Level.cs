using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [Header("下一個關卡的名稱")]
    public string NextSceneName;
    public int LevelID;

    public void NextScene()
    {
        if (NextSceneName == "Menu")
        {
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = false;
        }
        Application.LoadLevel(NextSceneName);
    }
}
