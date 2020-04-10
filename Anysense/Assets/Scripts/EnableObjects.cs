using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    private bool objectsEnabled = false;

    private void Awake()
    {
        foreach (GameObject gameobject in gameObjects)
        {
            gameobject.SetActive(objectsEnabled);
        }
    }

    public void ToggleObjects()
    {
        switch (objectsEnabled)
        {
            case true:
                objectsEnabled = false;
                break;
            case false:
                objectsEnabled = true;
                break;
        }
        foreach (GameObject gameobject in gameObjects)
        {
            gameobject.SetActive(objectsEnabled);
        }
    }
}
