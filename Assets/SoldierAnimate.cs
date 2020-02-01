using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimate : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;

    Vector3 movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.H)) 
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetBool("isRunning", false);
        }
        if (Input.GetMouseButton(0))
        {
            //animator.SetBool("isShooting", true);
        }

        
    }
}
