using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Level : MonoBehaviour 
{
    public AudioClip BackgroundMusic;
    public AudioClip Musicdead;

	// Use this for initialization
	void Start () 
	{
        Sound_Manager.instance.BackgroundMusic(BackgroundMusic);
	}
	
    public void playDeadMusic()
    {
        Sound_Manager.instance.PlaySingleSound(Musicdead);
    }
}
