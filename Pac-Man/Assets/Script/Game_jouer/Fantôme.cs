using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantôme : MonoBehaviour
{
    public float speed = 5f;
    public List<Vector2> waypoints;
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints != null && waypoints.Count > 0)
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        // Vérifier si le fantôme est arrivé au waypoint actuel
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
        {
            // Passer au prochain waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

        // Déplacer le fantôme vers le waypoint actuel
        Vector2 direction = (waypoints[currentWaypointIndex] - (Vector2)transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
