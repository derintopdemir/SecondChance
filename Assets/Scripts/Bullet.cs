using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<Rigidbody>().WakeUp();
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 4000, ForceMode.Force);
    }
    private void OnDisable()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().Sleep();
    }
}
