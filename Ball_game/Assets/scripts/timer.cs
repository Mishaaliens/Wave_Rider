using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required for UI elements

public class timer : MonoBehaviour
{
    public Text timerText;   // Reference to the UI Text component for displaying the timer
    private float timeElapsed;  // Elapsed time in seconds

    void Start()
    {
        timeElapsed = 0f;  // Initialize the elapsed time
    }

    void Update()
    {
        // Update the elapsed time
        timeElapsed += Time.deltaTime;

        // Format the elapsed time as minutes:seconds
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        string formattedTime = string.Format("{0:D2}:{1:D2}", minutes, seconds);

        // Display the formatted time on the UI
        if (timerText != null)
        {
            timerText.text = formattedTime;
        }
    }
}