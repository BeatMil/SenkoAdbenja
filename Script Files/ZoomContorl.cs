using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomContorl : MonoBehaviour
{
    GameStatus gameStatus;
    [SerializeField] AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameStatus.getZoomOutSkill(true);
        FindObjectOfType<SenkoController>().audioSource.PlayOneShot(audioClip);  
        Destroy(gameObject);
    }
}
