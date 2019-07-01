using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //parameters

    //cache
    LoseCollider lose;
    GameStatus gameStatus;

    void Start()
    {
        lose = FindObjectOfType<LoseCollider>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStartScene()
    {
        if (gameStatus != null)
        {
            gameStatus.resetGame();
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadGameover()
    {
        SceneManager.LoadScene("Gameover");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quited");
    }
}
