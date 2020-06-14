using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

	public GameObject objectWithScript;
	FMOD.Studio.EventInstance Movement;
	private bool moveForward;

	// Use this for initialization
	void Start()
	{
		Movement = FMODUnity.RuntimeManager.CreateInstance("event:/PlayerMovement");
		moveForward = objectWithScript.GetComponent<OVRPlayerController>();
	}

		// Update is called once per frame
		void FixedUpdate()
		{
				if (moveForward)
				{
					Movement.start();
				}
				else
				{
					Movement.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				}
		}
		private void OnDestroy()
		{
		Movement.release();
		Movement.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		}
}
