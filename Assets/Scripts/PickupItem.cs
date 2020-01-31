using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public GameObject interactTextObj;
    public Transform itemPickupLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && itemPickupLocation.childCount == 0)
        {
            interactTextObj.SetActive(true);
            interactTextObj.GetComponent<Text>().text = "E";
        }
        else if (itemPickupLocation.childCount > 0)
        {
            interactTextObj.SetActive(true);
            interactTextObj.GetComponent<Text>().text = "You Cannot Carry More Item";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable") && Input.GetAxis("Interact1") > 0 && itemPickupLocation.childCount == 0)
        {
            other.gameObject.transform.parent = itemPickupLocation.transform;
            other.gameObject.transform.position = itemPickupLocation.position;
            other.gameObject.transform.localScale *= 0.4f;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            interactTextObj.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactTextObj.SetActive(false);
        }
    }
}
