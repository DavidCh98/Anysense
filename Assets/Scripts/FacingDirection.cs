using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingDirection : MonoBehaviour
{
    [SerializeField] private Transform lookAt;

    private void Update()
    {
        transform.LookAt(lookAt);
    }
}
