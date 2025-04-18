using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    
    [Range(0f,1f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;
    
    public bool loop;
    
    [HideInInspector]
    public AudioSource source;
}

[System.Serializable]
public class SoundFX
{
    public string namesfx;
    public AudioClip sfx;
    [Range(0f,1f)]
    public float sfxvolume;
    [Range(0.1f,3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource sourceFX;
}

