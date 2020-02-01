using UnityEngine;
using System.Collections;

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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (this.gameObject.CompareTag("Player1")) {
            MoveAndRotateChar(new Vector3(Input.GetAxisRaw("HorizontalPlayer1") * speed * Time.deltaTime, 0, Input.GetAxisRaw("VerticalPlayer1") * speed * Time.deltaTime));
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
            MoveAndRotateChar(new Vector3(Input.GetAxisRaw("HorizontalPlayer2") * speed * Time.deltaTime, 0, Input.GetAxisRaw("VerticalPlayer2") * speed * Time.deltaTime));
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                trigger = true;
                AnimTrigger();
            }
            else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) { trigger = false;
                AnimTrigger();
            }
        }
    }

    void MoveAndRotateChar(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * Time.fixedDeltaTime));
    }
    void AnimTrigger()
    {
        FindObjectOfType<AudioManager>().Walk(trigger);
    }
}