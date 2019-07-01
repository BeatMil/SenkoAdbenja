using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSceneControl : MonoBehaviour
{
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    { 
        QuitGame();
    }

    void QuitGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
