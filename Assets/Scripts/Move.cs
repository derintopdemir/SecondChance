using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed = 100;
    float rotation;
    public float rotationSpeed = 100.0f;
    float translationVertical, translationHorizontal;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.gameObject.CompareTag("Player1")) {
             rotation = Input.GetAxis("HorizontalPlayer1") * rotationSpeed;
             translationVertical = Input.GetAxis("VerticalPlayer1") * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Ateş et
            }
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
             rotation = Input.GetAxis("HorizontalPlayer2") * rotationSpeed;
             translationVertical = Input.GetAxis("VerticalPlayer2") * speed;
            if (Input.GetKeyDown(KeyCode.B))
            {
                //Ateş et
            }
        }

        translationVertical *= Time.deltaTime;
        rotation *= Time.deltaTime;


        transform.Rotate(0, rotation, 0);
        rb.velocity = new Vector3(0, 0, translationVertical);
    }
}