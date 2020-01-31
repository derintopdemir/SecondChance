using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.LookAt(Camera.main.transform.position * -1f);
    }
}
