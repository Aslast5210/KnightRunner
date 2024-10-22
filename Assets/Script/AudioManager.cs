using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSound, fxSound;
    public AudioSource musicSource, fxSource;
    public static AudioManager instance;

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlayFX(string name)
    {
        Sound s = Array.Find(fxSound, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Not Found");
        }
        else
        {
            fxSource.PlayOneShot(s.clip);
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Theme");
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void FxVolume(float volume)
    {
        fxSource.volume = volume;
    }
}
