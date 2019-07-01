using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    GameStatus gameStatus;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // code for getting both parent and chile to othe scene
    //public void resetGame(GameObject child)
    //{
    //    Transform parentTransform = child.transform;

    //    // If this object doesn't have a parent then its the root transform.
    //    while (parentTransform.parent != null)
    //    {
    //        // Keep going up the chain.
    //        parentTransform = parentTransform.parent;
    //    }
    //    Destroy(parentTransform.gameObject);
    //    Debug.Log("reset!");
    //}

    //public static void DontDestroyChildOnLoad(GameObject child)
    //{
    //    Transform parentTransform = child.transform;

    //    // If this object doesn't have a parent then its the root transform.
    //    while (parentTransform.parent != null)
    //    {
    //        // Keep going up the chain.
    //        parentTransform = parentTransform.parent;
    //    }
    //    GameObject.DontDestroyOnLoad(parentTransform.gameObject);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitLoseCollider();
    }

    public void HitLoseCollider()
    {
        if (gameStatus.getCurrentLife() > 1)
        {
            gameStatus.lossLife();
            sceneLoader.LoadCurrentScene();
        }
        else
        {
            sceneLoader.LoadGameover();
        }
    }
}
