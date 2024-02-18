using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void Start()
    {
        audioMixer.SetFloat("volumeindex", 5);
    }

    public void SetVolume(float volumeindex)
    {
        audioMixer.SetFloat("volumeindex", volumeindex);
    }
}
