﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if (OVRInput.Controller.LTouch.Button.Start)
        //if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) >= 0.1)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (GameIsPaused && OVRInput.Controller.LTouch.Button.Two)
        {
            Restart();
        }
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Restart()
    {
        Debug.Log("Scene Restarted");
        //SceneManager.LoadScene("MainScene");
    }
    //public void QuitGame()
   // {
   //     Application.Quit();
   //     Debug.Log("You quited");
   // }
}
