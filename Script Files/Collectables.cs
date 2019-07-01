using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameObject spark;
    GameStatus gameStatus;
    new AudioBlock audio;
    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        audio = FindObjectOfType<AudioBlock>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
            GameObject particle = Instantiate(spark, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
            gameStatus.getCoin();
            audio.playCoinSound();
    }
}
