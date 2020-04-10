using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSoundCardPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartPlaying(Soundcard input)
    {
        audioSource.clip = input.clip;
        audioSource.loop = input.loop ;
        audioSource.volume = input.volume;
        audioSource.spatialBlend = 0;
        audioSource.Play();
    }

    public void StopPlaying()
    {
        audioSource.Stop();
    }
}
