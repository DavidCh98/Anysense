using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject robot;
    int current = 0;
    float speed = 0;//Don't touch this
    float maxSpeed= 1;
    float acceleration= 0.4f;
    float WPradius = 1;

    public float wait = 1.1f;
    bool keepPlaying = true;
    void Start()
    {
        StartCoroutine(SoundOut());
    }

    IEnumerator SoundOut()
    {
        while (keepPlaying)
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/RobotFootstep", gameObject);
            yield return new WaitForSeconds(wait);
            //FMODUnity.RuntimeManager.PlayOneShotAttached("event:/HumanFootstep", gameObject);
        }
    }
    void Update()
    {
        if (speed <= maxSpeed)
        {
            speed = speed + acceleration * Time.deltaTime;
        }
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            speed = 0;
            //for Random
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        Vector3 relativePos = waypoints[current].transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        
    }
        //FMODUnity.RuntimeManager.PlayOneShotAttached("event:/RobotFootstep", gameObject);
}
