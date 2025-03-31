using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class NumberSelect : MonoBehaviour

  
{
    int currentScene;
   
    string sceneName;
    int button_selected;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (sceneName == "One" && currentScene == 1)
        {
            button_selected = currentScene;
        }
       
        else if (sceneName == "Two" && currentScene == 2)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Three" && currentScene == 3)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Four" && currentScene == 4)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Five" && currentScene == 5)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Six" && currentScene == 6)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Seven" && currentScene == 7)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Eight" && currentScene == 8)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Nine" && currentScene == 9)
        {
            button_selected = currentScene;
        }

        //For 

        else if(sceneName == "Square 1" && currentScene == 10)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Triangle 2" && currentScene == 11)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Rectangle 3" && currentScene == 12)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Circle 4" && currentScene == 13)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Star 5" && currentScene == 14)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Rhombus 6" && currentScene == 15)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Pentagon 7" && currentScene == 16)
        {
            button_selected = currentScene;
        }
        else if (sceneName == "Hexagon 8" && currentScene == 17)
        {
            button_selected = currentScene;
        }
        UnityEngine.UI.Button button = GameObject.Find(button_selected.ToString()).GetComponent<UnityEngine.UI.Button>();
        button.interactable = false;
    }
    
    public void ChangeScene()
    {
        int button_name = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene(button_name);
    }

   public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadPrevScene()
    {
        SceneManager.LoadScene(currentScene - 1);
    }
    public void LoadHome()
    {
        SceneManager.LoadScene(0);
    }

}

