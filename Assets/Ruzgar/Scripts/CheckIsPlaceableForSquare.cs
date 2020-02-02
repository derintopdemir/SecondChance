using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckIsPlaceableForSquare : MonoBehaviour
{

    public Material[] materials;
    public MeshRenderer m_Renderer;

    [SerializeField] Material[] savedMaterials;

    [SerializeField] private Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    public bool isPlaceable;
    public bool isPlaced;
    public bool isTriggered;

    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        groundCheck = GameObject.Find("GroundCheck").transform;

        savedMaterials = m_Renderer.materials;
    }

    private void Update()
    {
        CheckIfPlaceable();
        CheckIfObjectTriggeredNull();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == gameObject.tag)
        {
            isTriggered = true;
        }
    }    

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == gameObject.tag)
        {
            isTriggered = false;
        }
    }

    void CheckIfPlaceable()
    {

        if (isTriggered)
        {
            isPlaceable = false;
            //m_Renderer.material = materials[1];

            Material[] redLows = new Material[m_Renderer.materials.Length];
            for (int i = 0; i < m_Renderer.materials.Length; i++)
            {
                redLows[i] = materials[1];
            }
            m_Renderer.materials = redLows;
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
                Material[] redLows = new Material[m_Renderer.materials.Length];
                for (int i = 0; i < m_Renderer.materials.Length; i++)
                {
                    redLows[i] = materials[1];
                }
                m_Renderer.materials = redLows;
            }
        }
    }

    private void CheckIsPlaced()
    {
        if (isPlaced)
        {
            //m_Renderer.material = materials[2];
            m_Renderer.materials = savedMaterials;

        }
        else
        {
            Material[] greenlows = new Material[m_Renderer.materials.Length];
            for (int i = 0; i < m_Renderer.materials.Length; i++)
            {
                greenlows[i] = materials[0];
            }
            m_Renderer.materials = greenlows;
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
