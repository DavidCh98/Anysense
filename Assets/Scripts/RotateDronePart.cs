using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDronePart : MonoBehaviour
{
    float rotationSpeed = 100.0f;
    void Update()
    {
        transform.Rotate(0.0f, rotationSpeed, 0.0f,Space.World);
    }
}
