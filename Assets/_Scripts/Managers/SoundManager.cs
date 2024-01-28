using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;  // Singleton instance

    public AudioClip backgroundMusic;    // Background music
    public AudioClip[] soundEffects;     // Array of sound effects

    private AudioSource musicSource;     // AudioSource for background music
    private AudioSource sfxSource;       // AudioSource for sound effects

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
        // Set up AudioSources
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Play background music on start
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 0.5f;  // Adjust the volume as needed
        musicSource.Play();
    }

    public void PlaySoundEffect(int index)
    {
        // Check if the index is valid
        if (index >= 0 && index < soundEffects.Length)
        {
            sfxSource.PlayOneShot(soundEffects[index]);
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
        sfxSource.volume = volume;
    }
}
