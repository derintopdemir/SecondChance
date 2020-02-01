using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;
    public float emptySpeed;
    public bool hungryObjectHit;
    [SerializeField]
    int playerNumber;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        if (!hungryObjectHit)
        {
            if (slider.value > targetProgress)
                slider.value -= emptySpeed * Time.deltaTime;
        } else if (hungryObjectHit)
        {
            slider.value = 1;
        }
        if(slider.value <= 0)
        {
            FindObjectOfType<UıManager>().DecreaseHealth(2, playerNumber);
        }
    }

    public void DecreaseProgress(float newProgress)
    {
        targetProgress = slider.value -= newProgress;
    }
}
