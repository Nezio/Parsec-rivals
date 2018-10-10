using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0, 1)]
    public float volume;
    //public float pitch;     // AudioManger sets pitch using timescale
    public bool dontUseScaledTime;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

