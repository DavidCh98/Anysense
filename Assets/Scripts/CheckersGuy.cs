using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersGuy : MonoBehaviour
{
    public GameObject[] waypoints;
    public Animator m_Animator;
    int current = 0;
    float speed = 0;//Don't touch this
    float maxSpeed = 1;
    float acceleration = 0.4f;
    float WPradius = 1;
    void Update()
    {
        if (speed <= maxSpeed)
        {
            speed = speed + acceleration * Time.deltaTime;
        }
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
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
            }
        }
        Vector3 relativePos = waypoints[current].transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }
}
