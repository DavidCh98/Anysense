using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    enum CarColor { red, orange, green };

    [Header("Objects")]
    [SerializeField] private MeshRenderer[] pedestrianTrafficMesh = null;
    [SerializeField] private MeshRenderer[] carTrafficScreen = null;

    [Header("Materials")]
    [SerializeField] private Material greenScreen = null;
    [SerializeField] private Material orangeScreen = null;
    [SerializeField] private Material redScreen = null;

    [Header("Setup")]
    [SerializeField] private Color red = Color.red;
    [SerializeField] private Color green = Color.green;
    [SerializeField, Range(0.001f, 5)] private float transitionLength = 0.001f;
    [SerializeField, Range(1, 5)] private float emission = 4;

    [Header("Timer")]
    [SerializeField, Range(0, 20)] private int timeOffset = 0;
    [SerializeField, Range(5, 50)] private int carGoTimer = 5;
    [SerializeField, Range(5, 20)] private int carStopTimer = 5;

    [Header("Debug")]
    public bool greenPedestrianLight = false;
    public bool transitioning = false;
    public bool active = true;

    private void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(timeOffset);
        while (active)
        {
            transitioning = false;
            greenPedestrianLight = false;
            SetCarColor(CarColor.green);
            SetPedestrianColor(red);
            yield return new WaitForSeconds(carGoTimer);
            SetCarColor(CarColor.orange);
            transitioning = true;
            yield return new WaitForSeconds(transitionLength);
            transitioning = false;
            greenPedestrianLight = true;
            SetCarColor(CarColor.red);
            SetPedestrianColor(green);
            yield return new WaitForSeconds(carStopTimer - transitionLength);
            StartCoroutine(PedestrianTransition());
            transitioning = true;
            yield return new WaitForSeconds(transitionLength);
        }
    }

    IEnumerator PedestrianTransition()
    {
        for (float i = 0; transitionLength > i; i += Time.deltaTime)
        {
            SetPedestrianColor(Color.Lerp(green, red, CodeLibrary.Remap(i, 0, transitionLength, 0, 1)));
            yield return new WaitForFixedUpdate();
        }
    }

    private void SetCarColor(CarColor color)
    {
        Material material = color == CarColor.green ? greenScreen : (color == CarColor.orange ? orangeScreen : redScreen);
        foreach (MeshRenderer carScreen in carTrafficScreen) carScreen.material = material;
    }

    private void SetPedestrianColor(Color color)
    {
        foreach (MeshRenderer pedestrianMesh in pedestrianTrafficMesh)
        {
            pedestrianMesh.material.SetColor("_Color", color);
            pedestrianMesh.material.SetColor("_EmissionColor", color * emission);
        }
    }
}
