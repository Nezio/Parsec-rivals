using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;   // timescale sets pitch
            s.source.loop = s.loop;
        }
    }

    private void Update()
    {
        foreach (Sound s in sounds)
        {
            if(!s.dontUseScaledTime)
                s.source.pitch = Time.timeScale;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogWarning("Sound: '" + name + "' not found!");
        }
        
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null)
        {
            s.source.PlayOneShot(s.source.clip);
        }
        else
        {
            Debug.LogWarning("Sound: '" + name + "' not found!");
        }

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public IEnumerator FadeOutStop(string name, float fadeTime)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float decrement = 0.1f;
        float waitTime = decrement * fadeTime;

        while (s.source.volume > 0)
        {
            s.source.volume -= decrement;
            yield return new WaitForSeconds(waitTime);
        }

        s.source.Stop();
        s.source.volume = s.volume;
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return (s.source.isPlaying);
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}
