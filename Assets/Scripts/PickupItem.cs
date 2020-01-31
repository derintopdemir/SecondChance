using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public GameObject interactTextObj;
    public Transform itemPickupLocation;
    public Material placedMaterial, correctMaterial, wrongMaterial;
    
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

        if (other.CompareTag("FillPart"))
        {
            if(itemPickupLocation.childCount > 0 && other.GetComponent<PartInfo>().objId == itemPickupLocation.GetChild(0).GetComponent<PartInfo>().objId)
            {
                interactTextObj.SetActive(true);
                interactTextObj.GetComponent<Text>().text = "E to Place";
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<MeshRenderer>().material = correctMaterial;
            }
            else
            {
                interactTextObj.SetActive(true);
                interactTextObj.GetComponent<Text>().text = "No Proper Item";
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<MeshRenderer>().material = wrongMaterial;
            }
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
        else if (other.CompareTag("FillPart") && Input.GetAxis("Interact1") > 0 && itemPickupLocation.childCount > 0 && other.GetComponent<PartInfo>().objId == itemPickupLocation.GetChild(0).GetComponent<PartInfo>().objId)
        {
            other.gameObject.GetComponent<MeshRenderer>().material = placedMaterial;
            Destroy(itemPickupLocation.GetChild(0).gameObject);
            interactTextObj.SetActive(false);
            other.gameObject.tag = "Untagged";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactTextObj.SetActive(false);
        }
        else if (other.CompareTag("FillPart"))
        {
            interactTextObj.SetActive(false);
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
