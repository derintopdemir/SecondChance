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
        }
    }

    void MoveAndRotateChar(Vector3 direction) => rb.MovePosition(transform.position + (direction * Time.fixedDeltaTime));
}