using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBlock : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip pulsLifeSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void playPulsLifeSound()
    {
        audioSource.PlayOneShot(pulsLifeSound);
    }


}
