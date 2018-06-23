using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Music : MonoBehaviour 
{
    public AudioClip MusicGameOver;

    // Use this for initialization
    void Start()
    {
        Sound_Manager.instance.BackgroundMusic(MusicGameOver);
    }

}

