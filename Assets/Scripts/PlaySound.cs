using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private SoundEvent[] soundEvents = new SoundEvent[0];

    public void StartCoroutine()
    {
        StartCoroutine(PlaySoundEvents());
    }

    private IEnumerator PlaySoundEvents()
    {
        foreach (SoundEvent soundEvent in soundEvents)
        {
            yield return new WaitForSeconds(soundEvent.waitTime);
            soundEvent.unityEvent.Invoke();
        }
    }
}

[Serializable]
public class SoundEvent
{
    public float waitTime = 0;
    public UnityEvent unityEvent = null;
}