using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite emptyBar, greenBar, orangeBar, redBar, yellowBar;
    public Stack<Image> activeOnes = new Stack<Image>(), deactiveOnes = new Stack<Image>();
    public bool isHealth = true;
    public int player;
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
        if(activeOnes.Count <= 0 && !isHealth)
        {
            if(!FindObjectOfType<ResourceManager>().CheckResource(ResourceManager.Type.Food, 5))
            {
                FindObjectOfType<UıManager>().DecreaseHealth(1, player);
            }
            else
            {
                while(deactiveOnes.Count > 0)
                {
                    IncreaseHealth();
                }
            }
            return;
        }

        bok = activeOnes.Pop();

        bok.sprite = emptyBar;

        deactiveOnes.Push(bok);

        if(activeOnes.Count <= 0 && isHealth)
        {
            //Time.timeScale = 0;
            GameObject.Find("AudioManagerMob").GetComponent<AudioSource>().enabled = false;
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
