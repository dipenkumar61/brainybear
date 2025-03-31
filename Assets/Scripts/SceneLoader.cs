using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    public void StartABC( )
    {
        SceneManager.LoadScene(18);
    }

    public void StartNumber()
    {
        SceneManager.LoadScene(1);
    }

    public void StartShapes()
    {
        SceneManager.LoadScene(10);
    }

    public void StartRhymes()
    {
        SceneManager.LoadScene(45);
    }

    public void StartAnimals()
    {
        SceneManager.LoadScene(51);
    }
    public void StartVehicles()
    {
        SceneManager.LoadScene(68);
    }
    public void LoadAnotherScene()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
