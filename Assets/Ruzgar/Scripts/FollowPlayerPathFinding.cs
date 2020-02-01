using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerPathFinding : MonoBehaviour
{
    [SerializeField] NavMeshSurface surface;
    [SerializeField] GameObject target;
    [SerializeField] NavMeshAgent agent;

    private bool isFollow = false;

    private void Start()
    {
        surface = FindObjectOfType<NavMeshSurface>();
    }

    void Update()
    {
        
       if (isFollow)
       {
            agent.SetDestination(target.transform.position);
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player2")
        {
            target = other.gameObject;
            agent.isStopped = false;
            isFollow = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player2")
        {
            isFollow = false;
            agent.isStopped = true;
        }

    }
}
