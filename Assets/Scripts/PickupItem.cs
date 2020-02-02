using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public Transform itemPickupLocation;
    public Material placedMaterial, correctMaterial, wrongMaterial;

    private float lastPickupTime;

    public void Update()
    {
        if(Input.GetButtonDown("Interact1") && itemPickupLocation.childCount > 0 && Time.time - lastPickupTime >= 0.5f)
        {
            lastPickupTime = Time.time;
            itemPickupLocation.GetChild(0).transform.localScale *= (1 / 0.4f);
            itemPickupLocation.GetChild(0).gameObject.GetComponent<Rigidbody>().useGravity = true;
            itemPickupLocation.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = true;
            itemPickupLocation.GetChild(0).transform.parent = null;
            gameObject.GetComponent<Fire>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && itemPickupLocation.childCount == 0)
        {
            Debug.Log("hello");
        }
        else if (itemPickupLocation.childCount > 0)
        {
        }

        if (other.CompareTag("FillPart"))
        {
            if(itemPickupLocation.childCount > 0 && other.GetComponent<PartInfo>().objId == itemPickupLocation.GetChild(0).GetComponent<PartInfo>().objId)
            {
                other.gameObject.SetActive(true);
            }
            else
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<MeshRenderer>().material = wrongMaterial;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable") && Input.GetAxis("Interact1") > 0 && itemPickupLocation.childCount == 0 && Time.time - lastPickupTime >= 0.5f)
        {
            lastPickupTime = Time.time;
            other.gameObject.transform.parent = itemPickupLocation.transform;
            other.gameObject.transform.position = itemPickupLocation.position;
            other.gameObject.transform.localScale *= 0.4f;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Fire>().enabled = false;
        }
        else if (other.CompareTag("FillPart") && Input.GetAxis("Interact1") > 0 && itemPickupLocation.childCount > 0 && other.GetComponent<PartInfo>().objId == itemPickupLocation.GetChild(0).GetComponent<PartInfo>().objId)
        {
            other.gameObject.GetComponent<MeshRenderer>().material = placedMaterial;
            Destroy(itemPickupLocation.GetChild(0).gameObject);
            other.gameObject.tag = "Untagged";
            gameObject.GetComponent<Fire>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
        }
        else if (other.CompareTag("FillPart"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
