using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;  // Singleton instance

    public AudioClip backgroundMusic;    // Background music
    public AudioClip RadioMusic;
    public AudioClip[] soundEffects;     // Array of sound effects
    private AudioSource musicSource;     // AudioSource for background music

    public float MusicVolume;
    public float SFXVolume;
    private bool isBGMset = false;
    // Dictionary to store the playing AudioSource for each sound effect index
    private Dictionary<int, AudioSource> playingSounds = new Dictionary<int, AudioSource>();

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SoundManager exists
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
        // Set up the background music AudioSource
        musicSource = gameObject.AddComponent<AudioSource>();
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.7f);
        SetMusicVolume(MusicVolume);
        SetSFXVolume(SFXVolume);
        // Play background music on start
        if(isBGMset == true)
        {
            PlayBackgroundMusic();
        }
        else
        {
            SetFirstBGM();
        }
    }

    public void PlayBackgroundMusic()
    {   
        musicSource.loop = true;
        musicSource.Play();
    }

    public void ChangeBackgroundMusic()
    {
        if (musicSource.clip == RadioMusic)
        {
            musicSource.clip = backgroundMusic;
        }
        else
        {
            musicSource.clip = RadioMusic;
        }
        PlayBackgroundMusic();
    }
    public void SetFirstBGM()
    {
        musicSource.clip = backgroundMusic;
    }
    public void PlaySoundEffect(int index)
    {
        // Check if the index is valid
        if (index >= 0 && index < soundEffects.Length)
        {
            // Stop the previously playing sound effect for this index, if any
            if (playingSounds.ContainsKey(index) && playingSounds[index] != null)
            {
                playingSounds[index].Stop();
                Destroy(playingSounds[index]); // Destroy the AudioSource component
            }

            // Create a new AudioSource for the sound effect
            AudioSource sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.clip = soundEffects[index];
            sfxSource.volume = SFXVolume;
            sfxSource.Play();

            // Add the AudioSource to the dictionary
            playingSounds[index] = sfxSource;
        }
        else
        {
            Debug.LogWarning("Invalid sound effect index.");
        }
    }

    public void SetMusicVolume(float val)
    {
        MusicVolume = val;

        // Set the volume for the background music
        musicSource.volume = MusicVolume;

        // Save the music volume to PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", val);
    }

    public void SetSFXVolume(float val)
    {
        SFXVolume = val;

        // Set the volume for all playing sound effects
        foreach (var kvp in playingSounds)
        {
            if (kvp.Value != null)
            {
                kvp.Value.volume = SFXVolume;
            }
        }

        // Save the SFX volume to PlayerPrefs
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
    }

    public void StopSoundEffect(int index)
    {
        // Check if the index is valid and there is a playing AudioSource for that index
        if (playingSounds.ContainsKey(index) && playingSounds[index] != null)
        {
            playingSounds[index].Stop();
            Destroy(playingSounds[index]); // Destroy the AudioSource component
            playingSounds.Remove(index);    // Remove from the dictionary
        }
        else
        {
            Debug.LogWarning("No playing sound effect found for the specified index.");
        }
    }

    public void SetSoundEffectLoop(int index) {
        if (playingSounds.ContainsKey(index) && playingSounds[index] != null)
        {
            playingSounds[index].loop = true;
        }
        else
        {
            Debug.LogWarning("No playing sound effect found for the specified index.");
        }
    }

    public void StopAllSFX() {
        foreach (KeyValuePair<int, AudioSource> sound in playingSounds) {
            sound.Value.Stop();
        }
    }

    public void StopAllSounds()
    {
        // Stop the background music
        musicSource.Stop();

        // Stop and destroy all playing sound effects
        foreach (var kvp in playingSounds)
        {
            if (kvp.Value != null)
            {
                kvp.Value.Stop();
                Destroy(kvp.Value); // Destroy the AudioSource component
            }
        }

        // Clear the dictionary
        playingSounds.Clear();
    }

    public void PauseAllSounds(bool setPause)
    {
        AudioListener.pause = setPause;
    }
}

