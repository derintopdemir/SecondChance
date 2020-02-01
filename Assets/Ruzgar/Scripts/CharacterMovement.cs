using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpSpeed = 4.29f;
    public float gravity = -9.81f;
    
    [SerializeField] private CharacterController controller;

    //HEALTH SECTION
    [SerializeField] TextMesh healthBar;
    public float health = 100f;
    public float damage = 10f;
    public bool isAttack = false;
    
    [SerializeField] private Animator animator;

    Vector3 movement;
    Vector3 velocity;

    [SerializeField] private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        print(movement.magnitude);
    }

    private void FixedUpdate()
    {

        SetDirections();
        Movement();
        ApplyAnimations();
    }


    void SetDirections()
    {
        if (movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = newDirection;
        } 
    }

    void Movement()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(movement * speed * Time.fixedDeltaTime);
        controller.Move(velocity * Time.deltaTime);

        print("moving");

        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        //animator.SetFloat("Speed", movement.magnitude);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }
    }

    private void ApplyAnimations()
    {
        animator.SetFloat("FromIdleToRun", movement.magnitude);

        if (movement.magnitude > 0.10f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            isAttack = true;

            StartCoroutine(UpdateHealth());

        }

    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Zombie")
        {
            isAttack = false;
        }
    }

    public IEnumerator UpdateHealth()
    {
        while (isAttack)
        {
            health -= damage;
            healthBar.text = health.ToString();

            yield return new WaitForSeconds(1f);
        }
        
        
    }

}
