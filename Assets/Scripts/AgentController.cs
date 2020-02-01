using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public GameObject player1, player2;
    public NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Vector3.Distance(player1.transform.position, transform.position) >= Vector3.Distance(player2.transform.position, transform.position) ? player2.transform.position : player1.transform.position;

        navMeshAgent.SetDestination(target);
    }
}
