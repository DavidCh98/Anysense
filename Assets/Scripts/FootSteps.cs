using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter studioEventEmitter = null;

    private CharacterController characterController = null;

    void Start()
	{
        characterController = GetComponent<CharacterController>();
	}

    void FixedUpdate()
    {
        if (characterController.velocity.x != 0 || characterController.velocity.z != 0)
        {
            if (studioEventEmitter.IsPlaying() == false) studioEventEmitter.Play();
        }
        else if (studioEventEmitter.IsPlaying()) studioEventEmitter.Stop();
    }
}
