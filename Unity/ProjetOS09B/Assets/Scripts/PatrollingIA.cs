using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingIA : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Transform[] waypoints;
    private int waypointIndex;
    Vector3 target;

    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        waypointIndex = 0;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    void UpdateDestination()
    {
        
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
}
