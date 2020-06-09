using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSwitcher : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private MeshRenderer meshRenderer = null;
    [SerializeField] private Color goColor = Color.red;
    [SerializeField] private Color stopColor = Color.green;
    [SerializeField, Range(0.001f, 5)] private float transitionLength;
    [SerializeField, Range(1, 5)] private float emission = 4;

    [Header("Timer")]
    [SerializeField] private bool timerEnable = true;
    [SerializeField, Range(5, 20)] private int goTimer = 0;
    [SerializeField, Range(5, 50)] private int stopTimer = 0;

    [Header("Debug")]
    [SerializeField] private bool switchGo;

    public bool greenLight = false;
    public bool transitioning = false;

    private bool go = true;
    private float transition = 0;
    private Color targetColor = Color.white;
    private Color currentColor = Color.white;
    private float timer = 0;

    private void Start()
    {
        SwitchColor();
    }

    private void Update()
    {
        //Debug
        if (switchGo) 
        {
            SwitchColor();
            switchGo = CodeLibrary.FlipBool(switchGo);
        }
        //\Debug

        //Timer
        if (timer < 0)
        {
            SwitchColor();
            timer = 0;
        } else if (timer > 0) timer -= Time.deltaTime;

        //Transitions
        if (transition > transitionLength)
        {
            SetColor(targetColor);
            transition = transitionLength;
            if (timerEnable) timer = go ? goTimer : stopTimer;
            greenLight = go;
            transitioning = false;
        } else if (transition < transitionLength)
        {
            transition += Time.deltaTime;
            CalculateColor();
        }
    }

    public void SwitchColor()
    {
        targetColor = go ? stopColor : goColor;
        transition = 0;
        transitioning = true;
        greenLight = false;
        go = CodeLibrary.FlipBool(go);
        currentColor = meshRenderer.material.color;
    }

    private void CalculateColor()
    {
        SetColor(Color.Lerp(currentColor, targetColor, CodeLibrary.Remap(transition, 0, transitionLength, 0, 1)));
    }

    private void SetColor(Color color)
    {
        meshRenderer.material.SetColor("_Color", color);
        meshRenderer.material.SetColor("_EmissionColor", color * emission);
    }
}
