using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Move : MonoBehaviour
{
    public float speed = 100;
    float translationVertical, translationHorizontal;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.gameObject.CompareTag("Player1")) {
             translationVertical = Input.GetAxis("VerticalPlayer1") * speed;
             translationHorizontal = Input.GetAxis("HorizontalPlayer1") * speed;
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
             translationVertical = Input.GetAxis("VerticalPlayer2") * speed;
             translationHorizontal = Input.GetAxis("HorizontalPlayer2") * speed;
        }

        translationHorizontal *= Time.deltaTime;
        translationVertical *= Time.deltaTime;
        

        rb.velocity = new Vector3(translationHorizontal, 0, translationVertical);
    }
}