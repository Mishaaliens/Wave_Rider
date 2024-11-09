using UnityEngine;
using UnityEngine.UI;
using System.Collections;  // This is required for IEnumerator

public class coinhit : MonoBehaviour
{
    public float rotationSpeed = 100f;   // Rotation speed for the coin
    public AudioSource coinSound;        // Audio source for the coin collection sound
    public static int score = 0;         // Score variable to track total coins collected
    public Text scoreText;               // UI Text element to display the score

    void Start()
    {
        // Ensure the score starts at 0 at the beginning of the game
        scoreText.text = "Score: " + score;

        // Ensure Play on Awake is disabled
        if (coinSound != null && coinSound.playOnAwake)
        {
            coinSound.playOnAwake = false;  // Ensures sound won't play at the start
        }
    }

    void Update()
    {
        // Rotate the coin around the Z-axis (rotating forward)
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the ball hits the coin
        if (other.CompareTag("Player"))  // Assuming the ball has a "Player" tag
        {
            // Increment the score
            score++;
            scoreText.text = "Score: " + score;

            // Play the coin collection sound if AudioSource is available
            if (coinSound != null)
            {
                coinSound.Play();
            }

            // Disable the coin object after it is collected to let the sound finish
            StartCoroutine(DestroyCoin());
        }
    }

    IEnumerator DestroyCoin()
    {
        // Wait for the sound to finish playing
        yield return new WaitForSeconds(coinSound.clip.length);

        // Destroy the coin object
        Destroy(gameObject);
    }
}
