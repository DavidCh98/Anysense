using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSwitcher : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color goColor;
    [SerializeField] private Color stopColor;

    [SerializeField] private bool active;

    private bool isActive;

    private void Start()
    {
        active = isActive;
        SetGo(isActive);
    }

    private void Update()
    {
        SetGo(active);
    }

    public bool SetGo(bool active)
    {
        if (active != isActive)
        {
            isActive = active;
            if (isActive == true)
            {
                SetColor(goColor);
            }
            else SetColor(stopColor);
        }
        return isActive;
    }

    private void SetColor(Color color)
    {
        meshRenderer.material.SetColor("_Color", color);
        
        meshRenderer.material.SetColor("_EmissionColor", color);
    }
}
