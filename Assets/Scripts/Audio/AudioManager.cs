using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public SoundFX[] soundFXs;
    public static AudioManager instance;
    
    /*public Slider musicSlider;
    public Slider SfxSlider;*/
    private void Awake()
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
        DontDestroyOnLoad(this.gameObject);
        MusicBG();
        soundEffect();
    }

    private void Update()
    {
        //slide();
        
    }

    private void Start()
    {
        PlayMBG("MenuGame");
    }
    
    public void soundEffect()
    {
        foreach (SoundFX s in soundFXs)
        {
            s.sourceFX = gameObject.AddComponent<AudioSource>();
            s.sourceFX.clip = s.sfx;
           
            s.sourceFX.volume = s.sfxvolume;
            s.sourceFX.pitch = s.pitch;
            
        }
    }
    
    public void PlayFX(string nameFX)
    {
        SoundFX s =Array.Find(soundFXs, soundfx => soundfx.namesfx == nameFX);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + nameFX + " not found!");
            return;
        }
        s.sourceFX.Play();
    }
    
    

    public void MusicBG()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
           
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void PlayMBG(string name)
    {
        Sound s =Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    
    public void StopMBG(string name)
    {
        Sound s =Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    
    /*private void slide()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = musicSlider.value;
        }
        foreach (SoundFX s in soundFXs)
        {
            s.sourceFX.volume = SfxSlider.value;
        }
    }*/
    /*private void slideMusic()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = musicSlider.value;
        }
    }*/
}
