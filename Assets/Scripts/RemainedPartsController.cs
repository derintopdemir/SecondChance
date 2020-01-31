using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainedPartsController : MonoBehaviour
{
    public Text uiText;

    // Update is called once per frame
    void Update()
    {
        uiText.text = GameObject.FindGameObjectsWithTag("FillPart").Length.ToString();
    }
}
