using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Music : MonoBehaviour 
{
    public AudioClip titleScreenMusic;

	// Use this for initialization
	void Start () 
	{
        Sound_Manager.instance.BackgroundMusic(titleScreenMusic);
	}
}

