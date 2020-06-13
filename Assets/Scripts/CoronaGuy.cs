using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaGuy : MonoBehaviour
{
    public GameObject[] waypoints;
    public Animator m_Animator;
    int current = 0;
    float speed = 0;//Don't touch this
    float maxSpeed = 1.5f;
    float acceleration = 0.6f;
    float WPradius = 1;
    void Update()
    {
        if (speed <= maxSpeed)
        {
            speed = speed + acceleration * Time.deltaTime;
        }
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            Vector3 relativePos = waypoints[current].transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
            current++;
            if (current >= waypoints.Length)
            {
                speed = 0;
                current = 0;
                maxSpeed = 0;
                acceleration = 0;
                WPradius = 0;
                //stopWalkingAnimation
                m_Animator.SetBool("StopWalking", true);
                transform.Rotate(0, 90, 0, Space.World);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }
}

