using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite emptyBar, greenBar, orangeBar, redBar, yellowBar;
    public Stack<Image> activeOnes = new Stack<Image>(), deactiveOnes = new Stack<Image>();
    Image bok;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            activeOnes.Push(transform.GetChild(i).GetComponent<Image>());
        }
    }

    public void DecreaseHealth()
    {
        bok = activeOnes.Pop();

        bok.sprite = emptyBar;

        deactiveOnes.Push(bok);

        if(activeOnes.Count <= 0)
        {
            Time.timeScale = 0;
        }
    }
    public void IncreaseHealth()
    {
        bok = deactiveOnes.Pop();

        if (0 <= activeOnes.Count && activeOnes.Count < 2)
        {
            bok.sprite = redBar;
        }
        else if (activeOnes.Count < 4)
        {
            bok.sprite = orangeBar;
        }
        else if (activeOnes.Count < 7)
        {
            bok.sprite = yellowBar;
        }
        else
        {
            bok.sprite = greenBar;
        }

        activeOnes.Push(bok);
    }
}
