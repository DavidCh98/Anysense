using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVibrate : MonoBehaviour
{
    private enum Hand { left, right };

    [SerializeField] private Hand hand;
    [SerializeField] private float amplitude = 0.2f;
    [SerializeField] private float frequency = 1f;

    private bool isVibrating = false;
    private OVRInput.Controller controller;
    private float currentAmplitude = 0;

    private void OnEnable()
    {
        if (hand == Hand.right)
        {
            controller = OVRInput.Controller.RTouch;
            return;
        }
        controller = OVRInput.Controller.LTouch;
    }

    public void LateUpdate()
    {
        if (isVibrating == false && currentAmplitude > 0)
        {
            OVRInput.SetControllerVibration(0, 0, controller);
            currentAmplitude = 0.0f;
        }
        isVibrating = false;
    }

    public void ReportVibration()
    {
        if (isVibrating == false)
        {
            OVRInput.SetControllerVibration(frequency, amplitude, controller);
            currentAmplitude = amplitude;
            isVibrating = true;
        }
    }
}
