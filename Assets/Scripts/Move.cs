using UnityEngine;
using System.Collections;
using System;

// A very simplistic car driving on the x-z plane.

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed;
    float rotation;
    [SerializeField]
    float rotationSpeed;
    Rigidbody rb;
    bool trigger;

    [SerializeField] GameObject gun;
    [SerializeField] GameObject gunParent;

    Vector3 movement1;
    Vector3 movement2;
    Vector3 move1;
    Vector3 move2;

    [SerializeField] Animator animator;

    Quaternion newRbDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement1.x = Input.GetAxis("HorizontalPlayer2");
        movement1.z = Input.GetAxis("VerticalPlayer2");

        movement2.x = Input.GetAxis("HorizontalPlayer1");
        movement2.z = Input.GetAxis("VerticalPlayer1");
    }

    void FixedUpdate()
    {



        if (this.gameObject.CompareTag("Player1")) {

            move2 = new Vector3(Input.GetAxisRaw("HorizontalPlayer1") * speed * Time.deltaTime, -9.81f, Input.GetAxisRaw("VerticalPlayer1") * speed * Time.deltaTime);
            MoveAndRotateChar(move2);

            ApplyAnimationsForPlayer1();

            if (movement2.magnitude > 0.3f)
            {
                Quaternion newDirection = Quaternion.LookRotation(movement2, Vector3.up);
                transform.rotation = newDirection;
                Debug.Log("Inside: " + transform.rotation.y);
            }
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
            if (Input.GetAxis("HorizontalPlayer2") != 0 || Input.GetAxis("VerticalPlayer2") != 0) {
                move1 = new Vector3(Input.GetAxisRaw("HorizontalPlayer2") * speed * Time.deltaTime, -9.81f, Input.GetAxisRaw("VerticalPlayer2") * speed * Time.deltaTime);
                MoveAndRotateChar(move1);
                
            }

            ApplyAnimationsForPlayer2();

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                trigger = true;
                AnimTrigger();
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                trigger = false;
                AnimTrigger();
            }

            if (movement1.magnitude > 0.3f)
            {
                Quaternion newDirection = Quaternion.LookRotation(movement1, Vector3.up);
                transform.rotation = newDirection;
                Debug.Log("Inside: " + transform.rotation.y);
            }
        }

        

    }

    private void ApplyAnimationsForPlayer1()
    {
        //RUNNING
        if (move2.magnitude > 10f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //SHOOTING PRESSING G
        if (Input.GetKey(KeyCode.Keypad1))
        {

            animator.SetBool("isShooting", true);
        }
        else if (!Input.GetKey(KeyCode.Keypad1))
        {
            animator.SetBool("isShooting", false);
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            animator.SetBool("isHit", true);
        }
        else if (!Input.GetKey(KeyCode.Keypad2))
        {
            animator.SetBool("isHit", false);
        }

        //DYING
        if (Input.GetKeyDown(KeyCode.Keypad3)) { animator.SetBool("isDead", true); }
    }

    private void ApplyAnimationsForPlayer2()
    {

        //RUNNING
        if (move1.magnitude > 10f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //SHOOTING PRESSING G
        if (Input.GetKey(KeyCode.G))
        {

            animator.SetBool("isShooting", true);
        }
        else if (!Input.GetKey(KeyCode.G))
        {
            animator.SetBool("isShooting", false);
        }

        if (Input.GetKey(KeyCode.H))
        {
            animator.SetBool("isHit", true);
        }
        else if (!Input.GetKey(KeyCode.H))
        {
            animator.SetBool("isHit", false);
        }

        //DYING
        if (Input.GetKeyDown(KeyCode.K)) { animator.SetBool("isDead", true); }
    }

    void MoveAndRotateChar(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * Time.fixedDeltaTime));
        //rb.MoveRotation(newRbDirection);
    }

    void AnimTrigger()
    {
        FindObjectOfType<AudioManager>().Walk(trigger);
    }

    
}