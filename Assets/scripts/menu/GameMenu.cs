using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitPressed()
    {
        SceneManager.LoadScene("Scenes/menu");
    }


    public void ContinuePressed()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
