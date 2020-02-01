using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;
    public float fillSpeed = 0.5f;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        if (slider.value > targetProgress)
            slider.value -= fillSpeed * Time.deltaTime;
    }

    public void DecreaseProgress(float newProgress)
    {
        targetProgress = slider.value -= newProgress;
    }
}
