using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainMirrorStuff : MonoBehaviour
{
    [SerializeField] private Transform positionTrack;


    private void Update()
    {
        CodeLibrary.SetY(transform, positionTrack.position.y);
        CodeLibrary.SetZ(transform, positionTrack.position.z);
    }
}
