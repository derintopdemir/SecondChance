using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public GameObject player1, player2;
    public NavMeshAgent navMeshAgent;

    Vector3 target;
    GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        target = Vector3.Distance(player1.transform.position, transform.position) >= Vector3.Distance(player2.transform.position, transform.position) ? player2.transform.position : player1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(((other.CompareTag("Player1") || other.CompareTag("Player2")) && (targetObj == null || other.CompareTag("Binalar")) || (other.CompareTag("Binalar") && targetObj == null)))
        {
            targetObj = other.gameObject;
            target = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player1") || other.CompareTag("Player2") || other.CompareTag("Binalar"))
        {
            targetObj = null;
        }
    }
}
