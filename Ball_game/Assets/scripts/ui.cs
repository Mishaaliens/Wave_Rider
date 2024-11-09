using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{

     public void StartGame()
    {

            SceneManager.LoadScene("Game");
    }
    public void HowGame()
    {

            SceneManager.LoadScene("settings");
    }
    public void BackGame()
    {
        SceneManager.LoadScene("UI");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}