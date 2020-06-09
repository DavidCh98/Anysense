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
    [SerializeField] private Color goColor = Color.red;
    [SerializeField] private Color stopColor = Color.green;
    [SerializeField, Range(0.001f, 5)] private float transitionLength = 0.001f;
    [SerializeField, Range(1, 5)] private float emission = 4;

    [Header("Timer")]
    [SerializeField] private bool timerEnable = true;
    [SerializeField, Range(5, 20)] private int goTimer = 0;
    [SerializeField, Range(5, 50)] private int stopTimer = 0;

    [Header("Debug")]
    [SerializeField] private bool pedestrianGo;

    public bool greenLight = false;
    public bool transitioning = false;

    private bool go = true;
    private float transition = 0;
    private Color targetColor = Color.white;
    private Color currentColor = Color.white;
    private float timer = 0;
    private bool transitionIgnore = false;

    private void Start()
    {
        SwitchPedestrianColor();
    }

    private void Update()
    {
        //Debug
        if (pedestrianGo)
        {
            SwitchPedestrianColor();
            pedestrianGo = CodeLibrary.FlipBool(pedestrianGo);
        }
        //\Debug

        //Timer
        if (timer < 0)
        {
            SwitchPedestrianColor();
            timer = 0;
        }
        else if (timer > 0) timer -= Time.deltaTime;

        //Transitions
        if (transition > transitionLength)
        {
            SetPedestrianColor(targetColor);
            SetCarColor(go ? CarColor.green : CarColor.red);
            transition = transitionLength;
            if (timerEnable) timer = go ? goTimer : stopTimer;
            greenLight = go;
            transitioning = false;
        }
        else if (transition < transitionLength)
        {
            transition += Time.deltaTime;
            CalculatePedestrianColor();
        }
    }

    public void SwitchPedestrianColor()
    {
        targetColor = go ? stopColor : goColor;
        transition = 0;
        transitioning = true;
        greenLight = false;
        SetCarColor(CarColor.orange);
        go = CodeLibrary.FlipBool(go);
        currentColor = pedestrianTrafficMesh[0].material.color;
    }

    private void CalculatePedestrianColor()
    {
        SetPedestrianColor(Color.Lerp(currentColor, targetColor, CodeLibrary.Remap(transition, 0, transitionLength, 0, 1)));
    }

    private void SetPedestrianColor(Color color)
    {
        foreach (MeshRenderer pedestrianMesh in pedestrianTrafficMesh)
        {
            pedestrianMesh.material.SetColor("_Color", color);
            pedestrianMesh.material.SetColor("_EmissionColor", color * emission);
        }
    }

    private void SetCarColor(CarColor color)
    {
        Material material = color == CarColor.green ? greenScreen : (color == CarColor.orange ? orangeScreen : redScreen);
        foreach (MeshRenderer carScreen in carTrafficScreen) carScreen.material = material;
    }
}
