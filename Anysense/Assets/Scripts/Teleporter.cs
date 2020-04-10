using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeStart { stop, start };

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Locations[] locations;
    [SerializeField] private HappinessMeter happinessMeter;

    private void Awake()
    {
        if (locations.Length == 0)
        {
            Debug.LogError("Add locations.");
            return;
        }
        gameObject.transform.position = locations[0].position.position;
        gameObject.transform.rotation = locations[0].position.rotation;
    }

    public void GoToLocation(int location)
    {
        if (location >= locations.Length) return;
        if (locations[location].timeStart == TimeStart.start)happinessMeter.StartCounting();
        else happinessMeter.StopCounting();
        transform.position = locations[location].position.position;
        transform.rotation = locations[location].position.rotation;
    }
}

[System.Serializable]
public class Locations
{ 
    [SerializeField] public string name;
    [SerializeField] public Transform position;
    [SerializeField] public TimeStart timeStart;
}