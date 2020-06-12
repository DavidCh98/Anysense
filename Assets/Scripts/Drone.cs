using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    Transform myTrans;

    //how long to keep moving up or down until switching direction
    public float verticalTime = 2f;
    //how fast to move vertically
    public float verticalSpeed = 0.5f;
    //how fast to move forward
    public float moveSpeed = 1f;

    void Start()
    {
        myTrans = this.transform;
        StartCoroutine(Rise());
    }

    void Update()
    {
        myTrans.Translate(myTrans.forward * moveSpeed * Time.deltaTime);
    }

    IEnumerator Rise()
    {
        float t = verticalTime;
        while (t > 0f)
        {
            myTrans.Translate(myTrans.up * verticalSpeed * Time.deltaTime);
            t -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        float t = verticalTime;
        while (t > 0f)
        {
            myTrans.Translate(-myTrans.up * verticalSpeed * Time.deltaTime);
            t -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Rise());
    }
}
