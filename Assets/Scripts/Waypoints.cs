using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject drone;
    int current = 0;
    float speed = 0;//Don't touch this
    float maxSpeed= 3;
    float acceleration= 0.4f;
    float WPradius = 1;

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
           current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }
}
