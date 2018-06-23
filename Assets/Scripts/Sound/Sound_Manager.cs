using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour {

    static Sound_Manager _instance = null;

    public AudioSource music;
    public AudioSource sfxSource;

	// Use this for initialization
	void Awake () {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }
	
    public void PlaySingleSound (AudioClip clip, float volume =1.0f)
    {
        sfxSource.clip = clip;
        sfxSource.volume = volume;

        sfxSource.Play();

    }

    public void BackgroundMusic(AudioClip clip, float volume = 1.0f)
    {
        music.clip = clip;
        music.volume = volume;

        music.loop = true;

        music.Play();
    }

    public void PauseBackGroundMusic ()
    {
        music.Pause();
    }

    public void UnPauseBackGorundMusic()
    {
        music.UnPause();
    }

    public static Sound_Manager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }
}
