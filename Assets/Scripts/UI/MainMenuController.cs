using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // public CanvasGroup OptionPanel;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level01");
    }

    public void Rules()
    {
        SceneManager.LoadSceneAsync("Rules");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}