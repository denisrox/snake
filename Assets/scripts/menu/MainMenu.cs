using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGamePressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/Game");
    }


    public void ExitPressed()
    {
        Application.Quit();
    }
}
