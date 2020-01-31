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
    float translationHorizontal;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.gameObject.CompareTag("Player1")) {
            MoveAndRotateChar(new Vector3(0, 0, Input.GetAxis("VerticalPlayer1") * speed * Time.deltaTime), Quaternion.Euler(0, Input.GetAxis("HorizontalPlayer1") * rotationSpeed,0));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Ateş et
            }
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
            MoveAndRotateChar(new Vector3(0, 0, Input.GetAxis("VerticalPlayer2") * speed * Time.deltaTime), Quaternion.Euler(0, Input.GetAxis("HorizontalPlayer2") * rotationSpeed, 0));
            if (Input.GetKeyDown(KeyCode.B))
            {
                //Ateş et
            }
        }
    }

    void MoveAndRotateChar(Vector3 direction, Quaternion rotation)
    {
        transform.Translate(direction);
        rb.MoveRotation(transform.rotation * rotation);
        Vector3 targetPos = transform.position + direction * Time.deltaTime;
        targetPos.y = 0.5f;
        rb.MovePosition(targetPos);
    }
}