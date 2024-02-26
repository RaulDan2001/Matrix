using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip musicClip;
    

    void Start()
    {
        audioSource.clip = musicClip;
        audioSource.Play();
    }

    
}
