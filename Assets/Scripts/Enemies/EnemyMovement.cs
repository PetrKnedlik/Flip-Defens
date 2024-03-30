using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 5f; 
    public float reachThreshold = 0.1f; // How close to get to a waypoint 

    private int currentWaypointIndex = 0; 

    void Update()
    {
        if (waypoints.Count > 0) 
        {
            MoveTowardsWaypoint(); 
        }
    }

    private void MoveTowardsWaypoint()
    {
        Vector2 targetPosition = new Vector2(waypoints[currentWaypointIndex].position.x,
                                             waypoints[currentWaypointIndex].position.y);
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

        // Smooth movement using Vector2.MoveTowards
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

        // Check if reached waypoint
        if (Vector2.Distance(currentPosition, targetPosition) < reachThreshold)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                ReachedEnd(); 
            }
        }
    }

    void ReachedEnd()
    {
        // Logika co dělat, když nepřítel dosáhne konce (poškození základny, zničení atd.)
        Destroy(gameObject); // Například zničení nepřítele 
    }
}
