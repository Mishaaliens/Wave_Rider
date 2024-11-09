using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // For restarting the scene

public class GameOverManager : MonoBehaviour
{
    public Text gameOverText;        // Reference to the "Game Over" UI text
    public Text winText;             // Reference to the "You Win" UI text
    public Button replayButton;      // Reference to the Replay button
    public Button menuButton;        // Reference to the Menu button
    public AudioClip gameOverClip;   // Audio clip to play on game over
    private AudioSource audioSource; // AudioSource to play the clip
    public Text scoreText;           // Reference to the score UI text
    public MusicManager musicManager; // Reference to the MusicManager

    void Start()
    {
        // Try to get the AudioSource component; if not found, add one.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource found on the GameOverManager. Adding one.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Hide the Game Over text, Win text, and Replay/ Menu buttons at the start
        if (gameOverText != null)
            gameOverText.enabled = false;

        if (winText != null)
            winText.enabled = false;

        if (replayButton != null)
        {
            replayButton.gameObject.SetActive(false);
            replayButton.onClick.AddListener(RestartGame);  // Link Replay button to the restart function
        }
        else
        {
            Debug.LogError("Replay button is not assigned.");
        }

        if (menuButton != null)
        {
            menuButton.gameObject.SetActive(false);
            menuButton.onClick.AddListener(GoToMenu);  // Link Menu button to the go to menu function
        }
        else
        {
            Debug.LogError("Menu button is not assigned.");
        }
    }

    public void ShowGameOver(bool hasWon)
    {
        if (hasWon)
        {
            // Display the Win text
            if (winText != null)
                winText.enabled = true;
            
            // Hide the Game Over text
            if (gameOverText != null)
                gameOverText.enabled = false;
        }
        else
        {
            // Display the Game Over text
            if (gameOverText != null)
                gameOverText.enabled = true;
            
            // Hide the Win text
            if (winText != null)
                winText.enabled = false;
        }

        if (replayButton != null)
            replayButton.gameObject.SetActive(true);

        if (menuButton != null)
            menuButton.gameObject.SetActive(true);

        // Play the game over audio clip if it exists
        if (audioSource != null && gameOverClip != null && !hasWon)
        {
            audioSource.PlayOneShot(gameOverClip); // Play the game over audio clip
        }

        // Stop the music if MusicManager is assigned
        if (musicManager != null)
        {
            musicManager.StopMusic();
        }

        // Pause the game by setting time scale to 0
        Time.timeScale = 0f;
    }

    // Function to restart the game when Replay button is clicked
    public void RestartGame()
    {
        // Reset the score to zero
        coinhit.score = 0;

        // Update the score UI to reflect the reset
        if (scoreText != null)
        {
            scoreText.text = "Score: " + coinhit.score;
        }

        // Reset time scale back to normal and reload the scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Function to go back to the main menu
    public void GoToMenu()
    {
        // Stop the music if MusicManager is assigned
        if (musicManager != null)
        {
            musicManager.StopMusic();
        }

        // Load the main menu scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("UI"); // Ensure "MainMenu" is the name of your main menu scene
    }
}
