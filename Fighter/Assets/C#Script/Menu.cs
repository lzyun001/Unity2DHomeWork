using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool ControlSound = false;
    [Header("聲音的按鈕")]
    public Image SoundImage;
    [Header("聲音開啟圖片")]
    public Sprite SoundOpenSprite;
    [Header("聲音關閉圖片")]
    public Sprite SoundCloseSprite;
    [Header("音樂拉霸")]
    public Slider SoundSlider;
    [Header("音效拉霸")]
    public Slider SoundEffectSlider;
    string SaveAudioSlider = "SaveAudioSlider";

    private void Start()
    {
        SoundControl();
        PlayerPrefs.GetFloat(SaveAudioSlider, SoundSlider.value);
    }

    private void Update()
    {
        AudioListener.volume = SoundSlider.value;
    }

    public void SoundControl()
    {
        ControlSound = !ControlSound;
        if (ControlSound == true)
        {
            AudioListener.pause = false;
            SoundImage.sprite = SoundOpenSprite;
        }
        else
        {
            AudioListener.pause = true;
            SoundImage.sprite = SoundCloseSprite;
        }
    }

    public void ChangeAudioSlider()
    {
        if (SoundSlider.value == 0)
        {
            ControlSound = true;
            SoundControl();
        }
        else
        {
            ControlSound = false;
            SoundControl();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        PlayerPrefs.SetFloat(SaveAudioSlider, SoundSlider.value);
        Application.LoadLevel("Level");
        
    }
}
