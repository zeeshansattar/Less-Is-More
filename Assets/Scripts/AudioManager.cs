﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.soundClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

     void Start()
     {
        //Play("Background Music");
     }


    public void Play(string name)
    {
       Sound s = Array.Find(sounds, Sounds => Sounds.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "Not Found!"); 
            return;
        }

        s.source.Play();
         
    }

}
