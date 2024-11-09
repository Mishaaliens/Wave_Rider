using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;  // Singleton instance to prevent duplicates
    private AudioSource musicSource;              // Audio source for the music

    void Awake()
    {
        // Check if there's already an instance of MusicManager
        if (instance == null)
        {
            // If not, set this as the instance and mark it to not be destroyed on scene load
            instance = this;
            DontDestroyOnLoad(gameObject);  // Prevent destruction of this GameObject when switching scenes
        }
        else if (instance != this)
        {
            // If an instance already exists and it's not this one, destroy this duplicate
            Destroy(gameObject);
        }

        // Ensure the AudioSource is attached to this GameObject
        musicSource = GetComponent<AudioSource>();
        if (musicSource == null)
        {
            Debug.LogError("No AudioSource found on the MusicManager!");
        }
    }

    public void SetVolume(float volume)
    {
        // Change the music volume dynamically
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }

    // Method to stop the music
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();  // Stop playing the music
        }
    }
}
