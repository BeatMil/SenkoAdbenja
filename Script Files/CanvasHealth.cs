using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHealth : MonoBehaviour
{
    [SerializeField] GameObject heart;
    [SerializeField] Transform positionTOPLEFT;
    GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        runningHeart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void runningHeart()
    {
        var trash = GameObject.FindGameObjectsWithTag("UI");
        foreach (var target in trash )
        {
            GameObject.Destroy(target);
            Debug.Log("trash destroyed");
        }

        int lengthBetweenHeart = 100;
        for (int i = 0; i < gameStatus.getCurrentLife(); i++)
        {
            if (i == 0)
            {
                Instantiate(heart, positionTOPLEFT);
            }
            else
            {
                Instantiate(heart, new Vector3(positionTOPLEFT.position.x + lengthBetweenHeart, positionTOPLEFT.position.y, 0), Quaternion.identity, positionTOPLEFT);
                lengthBetweenHeart += 100;
            }
        }
        lengthBetweenHeart = 0;
        Debug.Log("Running Heart");
    }
}
