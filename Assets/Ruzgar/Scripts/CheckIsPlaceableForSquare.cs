using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckIsPlaceableForSquare : MonoBehaviour
{
    [SerializeField] NavMeshSurface surface;

    [SerializeField] GameObject previousTriggered;

    public Material[] materials;
    public MeshRenderer m_Renderer;

    [SerializeField] private Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    public bool isPlaceable;
    public bool isPlaced;
    public bool isTriggered;

    private void Start()
    {
        surface = FindObjectOfType<NavMeshSurface>();
        m_Renderer = GetComponent<MeshRenderer>();
        groundCheck = GameObject.Find("GroundCheck").transform;
    }

    private void Update()
    {
        CheckIfPlaceable();
        CheckIfObjectTriggeredNull();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isTriggered = true;
        }
    }    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isTriggered = false;
        }
    }

    void CheckIfPlaceable()
    {

        if (isTriggered)
        {
            isPlaceable = false;
            m_Renderer.material = materials[1];
        }

        if (!isTriggered)
        {
            isPlaceable = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isPlaceable)
            {
                CheckIsPlaced();
            }
            else if (!isPlaceable)
            {
                m_Renderer.material = materials[1];
            }
        }
    }

    private void CheckIsPlaced()
    {
        if (isPlaced)
        {
            m_Renderer.material = materials[2];
        }
        else
        {
            m_Renderer.material = materials[0];
        }
    }

    private void CheckIfObjectTriggeredNull()
    {

        CheckIsPlaceableForSquare[] squares = FindObjectsOfType<CheckIsPlaceableForSquare>();

        foreach (CheckIsPlaceableForSquare square in squares)
        {
            if (square.isPlaced)
            {
                square.isTriggered = false;
            }
        }
    }
}
