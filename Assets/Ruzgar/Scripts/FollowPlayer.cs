using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public List<Transform> targets;

    [SerializeField] Camera cam;

    public Vector3 offset;

    private void Start()
    {
        offset.z = -10f;
    }

    private void FixedUpdate()
    {
        Move();
        Look();
        Zoom();
        //print(GetRayDistance());
    }

    

    private void Move()
    {
        if (targets.Count == 0) return;

        Vector3 centerPosition = GetCenterPosition();

        Vector3 newPositon = centerPosition + offset;

        transform.position = newPositon;
    }

    Vector3 GetCenterPosition()
    {
        if (targets.Count == 1)
        {
            transform.LookAt(targets[0].position);
            return transform.position = targets[0].position + offset;
        }

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    private float GetRayDistance()
    {
        if (targets[1] == null)
        {
            Debug.LogError("Second target doesn`t exist.");
        }


        float distance = Vector3.Distance(targets[0].position, targets[1].position);
        return distance;
    }

    void Zoom()
    {
        //float newZoom = Mathf.Lerp(10f, 100f, GetRayDistance() / 50f);

        if (GetRayDistance() < 6f) { return; }

        offset = Vector3.right * -8f + Vector3.up * GetRayDistance() * 1f + Vector3.forward * -GetRayDistance() * 0.85f;
    }

    private void Look()
    {
        transform.LookAt(GetCenterPosition());
    }
}
