using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform[] waypoints;

    int wayPointIndex;

    public float radius;

    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public Transform player;

    public bool canSeePlayer = true;

    public LayerMask targetMask;
    Vector3 target;
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();

        UpdateDestination();
    }

    private void Update()
    {

        if ((Vector3.Distance(transform.position, target) < 1) && !canSeePlayer)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
        else if (!canSeePlayer)
        {
            UpdateDestination();
        }

        if (canSeePlayer)
        {
            agent.SetDestination(player.position);
        }
    }


    //Updates the destination the enemy is going
    void UpdateDestination()
    {
        target = waypoints[wayPointIndex].position;
        agent.SetDestination(target);
    }

    //Iterates Waypoint
    void IterateWaypointIndex()
    {
        wayPointIndex++;

        if (wayPointIndex == waypoints.Length)
        {
            wayPointIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canSeePlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canSeePlayer = false;
        }
    }
}
