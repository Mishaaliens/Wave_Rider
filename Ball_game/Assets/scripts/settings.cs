using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // For scene navigation

public class settings : MonoBehaviour
{
    public Slider volumeSlider;    // Reference to the slider UI component
    public AudioSource musicSource; // Reference to the AudioSource playing the music
    public Button backButton;      // Reference to the back button

    void Start()
    {
        // Set the slider's value to match the current volume at the start
        if (musicSource != null)
        {
            volumeSlider.value = musicSource.volume;
        }

        // Add a listener to the slider to detect changes
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(volumeSlider.value); });

        // Add listener for the back button to go back to the main menu
        if (backButton != null)
        {
            backButton.onClick.AddListener(GoBackToMenu);
        }
        else
        {
            Debug.LogError("Back button not assigned in the Inspector!");
        }
    }

    // Method to adjust the music volume
    public void SetVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;  // Change the volume of the music
        }
    }

    // Method to load the main menu scene
    public void GoBackToMenu()
    {
        // Reset time scale if necessary (if paused, for example)
        Time.timeScale = 1f;
        SceneManager.LoadScene("UI");  // Replace "MainMenu" with your actual menu scene name
    }
}
