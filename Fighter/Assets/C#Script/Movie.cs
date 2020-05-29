using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    public VideoPlayer Movie_;
    float Timer;

    private void Start()
    {
        InvokeRepeating("CheckMovie", 3f, 0.1f);
    }

    private void Update()
    {
        /*Timer += Time.deltaTime;
        if (Timer > 3f)
        {
            if (Movie_.isPlaying == false)
            {

                Application.LoadLevel("Game");
            }
        }*/
    }
    private void CheckMovie()
    {
        if (Movie_.isPlaying == false)
        {

            Application.LoadLevel("Game");
        }
    }
}
