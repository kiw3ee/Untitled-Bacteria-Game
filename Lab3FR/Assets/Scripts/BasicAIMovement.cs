using UnityEngine;

public class BasicAIMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    public float detectionRadius = 10f;
    public float moveSpeed = 3f;
    public float waypointTolerance = 0.2f;

    private int currentWaypointIndex = 0;
    private bool isChasing = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            isChasing = true;
        }
        else if (isChasing && distanceToPlayer > detectionRadius)
        {
            isChasing = false;
        }

        if (isChasing)
        {
            MoveTowards(player.position);
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0)
            return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        MoveTowards(targetWaypoint.position);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < waypointTolerance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.forward = direction; // optional: face movement direction
    }
}