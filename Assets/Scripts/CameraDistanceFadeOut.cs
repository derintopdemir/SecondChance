using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistanceFadeOut : MonoBehaviour
{
    [SerializeField]
    GameObject object1, object2;
    Transform distance;

    void Update()
    {
        var distance = Vector3.Distance(object1.transform.position, object2.transform.position);

        Camera.main.orthographicSize = distance;
        if (Camera.main.orthographicSize <= 5) Camera.main.orthographicSize = 5;
        if (Camera.main.orthographicSize >= 45) Camera.main.orthographicSize = 45;
        
        transform.position = transform.parent.position + new Vector3(-2, 6, -3) + transform.forward * -1 * Camera.main.orthographicSize;
    }
}
