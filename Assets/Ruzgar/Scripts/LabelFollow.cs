using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 newPosition = offset + target.position;
        transform.position = newPosition;
    }
}
