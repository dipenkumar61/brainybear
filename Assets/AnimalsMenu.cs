using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AnimalsMenu : MonoBehaviour
{
    string button_name;
    int currentScene;

   

    // Start is called before the first frame update
    void Start()
    {
       
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void AnimalName()
    {
        button_name = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(button_name);

    }

    public void AnimalMenu()
    {

        SceneManager.LoadScene("Animal Menu");

    }
    public void MainMenu()
    {

        SceneManager.LoadScene("Menu");

    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadPrevScene()
    {
        SceneManager.LoadScene(currentScene - 1);
    }

   
}

