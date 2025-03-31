using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RhymesMenu : MonoBehaviour
{
    string button_name ;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void RhymeName()
    {
        button_name = EventSystem.current.currentSelectedGameObject.name;
       SceneManager.LoadScene(button_name);
        
    }

    public void RhymeMenu()
    {
        
        SceneManager.LoadScene("Rhymes Menu");

    }
    public void MainMenu()
    {

        SceneManager.LoadScene(0);

    }


}
