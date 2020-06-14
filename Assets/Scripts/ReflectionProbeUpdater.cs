using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionProbeUpdater : MonoBehaviour
{
    [SerializeField][Tooltip("How many times it should update per second")][Range(1, 90)] private float secondUpdate = 20;

    private ReflectionProbe reflectionProbe = null;
    private float updateSeconds;

    private void Awake()
    {
        reflectionProbe = GetComponent<ReflectionProbe>();
        updateSeconds = 1 / secondUpdate;
        StartCoroutine(ReflectionProbeUpdateLoop());
    }

    private IEnumerator ReflectionProbeUpdateLoop()
    {
        while (true)
        {
            reflectionProbe.RenderProbe();
            yield return new WaitForSeconds(updateSeconds);
        }
    }
}
