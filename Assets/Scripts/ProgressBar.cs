using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    int minimum, current;
    [SerializeField]
    Image mask, fill;
    [SerializeField]
    Color color;

    private void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)minimum;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }
}
