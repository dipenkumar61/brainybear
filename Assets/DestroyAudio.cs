using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("BackgroundAudio"));

    }
}
