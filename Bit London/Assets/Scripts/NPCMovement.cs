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
    [SerializeField] float speed;
    [SerializeField] bool check;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if (agent.remainingDistance < reachTargetRange)
        {
            GoToNextWaypoint();
        }*/
        
        if (!PauseMenu.gameIsPaused)
        {
            if (check)
            {
                GoToNextWaypoint();
            }
            else
            {
                if(agent == null)
                {
                    agent = GetComponent<NavMeshAgent>();
                }
                if (agent.remainingDistance < reachTargetRange)
                {
                    HumanPathFind();
                }
            }
        }
    }

    void GoToNextWaypoint()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < reachTargetRange)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
                currentWaypoint = 0;
            //Destroy(gameObject);
        }

        //agent.SetDestination(waypoints[currentWaypoint].transform.position);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, (speed / 100));
        transform.LookAt(waypoints[currentWaypoint].transform.position);
    }

    void HumanPathFind()
    {

        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
            currentWaypoint = 0;

        agent.SetDestination(waypoints[currentWaypoint].transform.position);
    }
}
