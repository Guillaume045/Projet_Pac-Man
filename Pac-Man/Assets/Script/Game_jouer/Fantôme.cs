using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantôme : MonoBehaviour
{
    public float speed = 2f;
    public float startDelay = 50f;
    public List<Vector2> waypoints;
    private Vector3 spawnPoint;
    private int currentWaypointIndex = 0;

    void Start()
    {
         
        spawnPoint = transform.position;
        Invoke("StartMovement", startDelay);
    }

    void StartMovement()
    {
        if (waypoints != null && waypoints.Count > 0)
        {
            MoveToWaypoint();
        }
        
    }

    void Update()
    {
        if (waypoints != null && waypoints.Count > 0)
        {
            MoveToWaypoint();
        }
       
    }

    void MoveToWaypoint()
    {
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

        Vector2 direction = (waypoints[currentWaypointIndex] - (Vector2)transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = spawnPoint;
        transform.rotation = Quaternion.identity;
        Invoke("ResetWaypoint", 0f);
    }

    void ResetWaypoint()
    {
        currentWaypointIndex = 0;
    }
}
