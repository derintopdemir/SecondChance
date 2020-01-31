using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistanceFadeOut : MonoBehaviour
{
    [SerializeField]
    GameObject object1, object2;

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(object1.transform.position, object2.transform.position);

        if(distance >  10)
        {
            Camera.main.fieldOfView = 70;
        } else if (distance > 15)
    }
}
