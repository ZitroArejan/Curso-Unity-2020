using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour {
    private int currentWaypointIndex;
    
    public Transform[] waypoints;
    private NavMeshAgent _navMeshAgent;
    void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update() {
        if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance) {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            _navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}