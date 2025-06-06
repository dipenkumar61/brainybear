﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneManaging : MonoBehaviour
{

    int continueLevel;
    
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Play()
    {
        if (PlayerPrefs.HasKey("levelAt"))
        {
            
            continueLevel = PlayerPrefs.GetInt("levelAt");
            
            if (continueLevel == 27)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(continueLevel);
            }
        }
        
        else
        {
            
           
            SceneManager.LoadScene(2);

        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}