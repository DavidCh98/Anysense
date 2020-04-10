using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportCollision : MonoBehaviour
{
    [SerializeField] private string collisionTag;
    [SerializeField] private CollisionVibrate collisionVibrate;
    [SerializeField] private OVRGrabber ovrGrabber;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(collisionTag) && ovrGrabber.grabbedObject == null) collisionVibrate.ReportVibration();
    }
}
