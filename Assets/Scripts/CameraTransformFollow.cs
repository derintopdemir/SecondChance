using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransformFollow : MonoBehaviour
{
    [SerializeField]
    GameObject object1, object2;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(object2.transform.position.x + (object1.transform.position.x - object2.transform.position.x) / 2f,
            transform.position.y,
            object2.transform.position.z + (object1.transform.position.z - object2.transform.position.z) / 2f);
    }
    //object2.transform.position.y + (object1.transform.position.y - object2.transform.position.y) / 2f
}
