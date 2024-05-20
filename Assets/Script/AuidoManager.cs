using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource; 
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] musicClips; 
    public AudioClip[] sfxClips; 

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlayMusic(string clipName, bool loop = true)
    {
        AudioClip clip = FindMusicClipByName(clipName);
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music clip not found: " + clipName);
        }
    }
    public void PlayMusicByIndex(int index, bool loop = true)
    {
        if (index >= 0 && index < musicClips.Length)
        {
            musicSource.clip = musicClips[index];
            musicSource.loop = loop;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid music index: " + index);
        }
    }

    public void PlaySFX(string clipName)
    {
        AudioClip clip = FindSFXClipByName(clipName);
        if (clip != null)
        {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
        else
        {
            Debug.LogWarning("SFX clip not found: " + clipName);
        }
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    private AudioClip FindMusicClipByName(string clipName)
    {
        for (int i = 0; i < musicClips.Length; i++)
        {
            if (musicClips[i].name == clipName)
            {
                return musicClips[i];
            }
        }
        return null;
    }

    private AudioClip FindSFXClipByName(string clipName)
    {
        for (int i = 0; i < sfxClips.Length; i++)
        {
            if (sfxClips[i].name == clipName)
            {
                return sfxClips[i];
            }
        }
        return null;
    }
}


