using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PlayingGame");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}

