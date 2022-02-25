using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] int currentWaypoint = 0;
    NavMeshAgent agent;
    [SerializeField] float reachTargetRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < reachTargetRange)
        {
            GoToNextWaypoint();
        }
    }

    void GoToNextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
            currentWaypoint = 0;
            //Destroy(gameObject);

        agent.SetDestination(waypoints[currentWaypoint].transform.position);
    }
}
