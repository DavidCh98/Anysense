using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerUnityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent = null;

    private void OnTriggerEnter(Collider other)
    {
        unityEvent.Invoke();
    }
}
