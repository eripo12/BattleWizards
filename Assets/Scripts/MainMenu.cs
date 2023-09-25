using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        // this is where background music will be initialized
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1); //loads index 1 in build
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
