using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCountDisplay : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<TMPro.TextMeshProUGUI>().SetText(FindObjectOfType<WaveController>().GetCurrentWave().ToString());
    }
}
