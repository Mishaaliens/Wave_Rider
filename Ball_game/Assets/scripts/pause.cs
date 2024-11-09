using UnityEngine;
using UnityEngine.SceneManagement;  // For loading scenes

public class pause : MonoBehaviour
{
    public string pausemenu = "UI";  // Name of the pause menu scene to load

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the specified pause menu scene
            SceneManager.LoadScene(pausemenu);
        }
    }
}
