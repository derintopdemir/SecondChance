using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{

    //Choosing placeable object section ==>>
    int placeableObjectIndex = 0;
    [SerializeField] public GameObject[] placeables;
    //[SerializeField] TextMesh placeableObjectLabel;
    //objects
    [SerializeField] private GameObject placeableObjectPrefab;
    [SerializeField] public GameObject currentPlaceableObject;
    [SerializeField] public GameObject environmentParent;
    [SerializeField] private KeyCode newObjectHotKey = KeyCode.B;
    [SerializeField] public KeyCode placeObjectKey = KeyCode.V;
    [SerializeField] public KeyCode changeObject = KeyCode.C;
    [SerializeField] public Camera cam;
    [SerializeField] public Transform target;
    [SerializeField] public float minerals = 100f;
    private float mouseWheelYRotation;

    private void Start()
    {
        cam.enabled = false;
    }

    void Update()
    {
        ChangePlaceableObject();
        //UpdateLabel();
        HandleNewObjectHotKey();

        if (currentPlaceableObject != null && minerals > 5f)
        {
            MoveCurrentPlaceableObjectToTarget();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
        
    }

    private void UpdateLabel()
    {
        switch (placeableObjectIndex)
        {
            case 0:
                //placeableObjectLabel.text = "Cube";
                break;
            case 1:
                //placeableObjectLabel.text = "Sphere";
                break;
            case 2:
                Debug.Log("Index out of bound");
                break;
        }
    }

    public void ChangePlaceableObject()
    {
        if (Input.GetKeyDown(changeObject))
        {
            placeableObjectIndex++;
            if (placeableObjectIndex == placeables.Length)
            {
                placeableObjectIndex = 0;
            }
            placeableObjectPrefab = placeables[placeableObjectIndex];
        }

        
    }

    public void HandleNewObjectHotKey()
    {
        if (Input.GetKeyDown(newObjectHotKey))
        {
            if (minerals > 5)
            {
                if (currentPlaceableObject == null)
                {
                    currentPlaceableObject = Instantiate(placeableObjectPrefab);
                    currentPlaceableObject.transform.SetParent(environmentParent.transform);


                }
                else
                {
                    Destroy(currentPlaceableObject);
                }
            }
            else
            {
                print("Not enough minerals to build");
            }

        }
    }

    //GRID SYSTEM ==>>

    public Vector3 GetCurrenObjectGridPos()
    {
        Vector3 gridPos = new Vector3(Mathf.RoundToInt(currentPlaceableObject.transform.position.x / 2f) * 2f, Mathf.RoundToInt(currentPlaceableObject.transform.position.y / 2f) * 2f, Mathf.RoundToInt(currentPlaceableObject.transform.position.z / 2f) * 2f);
        return gridPos;
    }

    private void MoveCurrentPlaceableObjectToTarget()
    {
        Ray ray = cam.ScreenPointToRay(target.position);
        if (Physics.Raycast(ray))
        {
            if (currentPlaceableObject != null)
            {
                currentPlaceableObject.transform.position = target.position; //first spawn current object on target
                currentPlaceableObject.transform.position = new Vector3(GetCurrenObjectGridPos().x, currentPlaceableObject.transform.position.y, GetCurrenObjectGridPos().z); // then sync the corrdinates to cift sayi
                currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, target.up);
            }
        }
    }

    //============= 

    private void RotateFromMouseWheel()
    {
        mouseWheelYRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.rotation = Quaternion.Euler(-90f, mouseWheelYRotation * 10f, currentPlaceableObject.transform.rotation.z);
        //currentPlaceableObject.transform.position = new Vector3(currentPlaceableObject.transform.position.x, mouseWheelYRotation, currentPlaceableObject.transform.position.z);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetKeyDown(placeObjectKey))
        {
            if (currentPlaceableObject == FindObjectOfType<CheckIsPlaceableForSquare>().gameObject)
            {
                if (FindObjectOfType<CheckIsPlaceableForSquare>().isPlaceable)
                {
                    FindObjectOfType<CheckIsPlaceableForSquare>().isPlaced = true;
                    currentPlaceableObject = null;
                }
                else if (!FindObjectOfType<CheckIsPlaceableForSquare>().isPlaceable)
                {
                    return;
                }
            }
            else if (currentPlaceableObject != FindObjectOfType<CheckIsPlaceableForSquare>().gameObject)
            {
                
            }
        }
    }
}
