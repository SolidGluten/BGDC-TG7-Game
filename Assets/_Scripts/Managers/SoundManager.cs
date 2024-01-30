using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;  // Singleton instance

    public AudioClip backgroundMusic;    // Background music
    public AudioClip[] soundEffects;     // Array of sound effects
    private AudioSource musicSource;     // AudioSource for background music

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

        // Play background music on start
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 0.2f;  // Adjust the volume as needed
        musicSource.Play();
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
            sfxSource.Play();

            // Add the AudioSource to the dictionary
            playingSounds[index] = sfxSource;
        }
        else
        {
            Debug.LogWarning("Invalid sound effect index.");
        }
    }

    public void SetVolume(float volume)
    {
        // Set the volume for both music and sound effects
        musicSource.volume = volume;

        // Set the volume for all playing sound effects
        foreach (var kvp in playingSounds)
        {
            if (kvp.Value != null)
            {
                kvp.Value.volume = volume;
            }
        }
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

    public void PausePlayAllSounds()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }
}

