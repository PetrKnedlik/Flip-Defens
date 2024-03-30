using UnityEngine;
using System.Collections.Generic;

public class EnemyPathfinder : MonoBehaviour
{
    public float speed = 5f;

    private List<Transform> waypoints; 

    void Start()
    {
        waypoints = new List<Transform>();
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject waypoint in waypointObjects)
        {
            waypoints.Add(waypoint.transform);
        }
    }
}
