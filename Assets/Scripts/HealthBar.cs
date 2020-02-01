using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Stack<GameObject> activeOnes = new Stack<GameObject>(), deactiveOnes = new Stack<GameObject>();
    GameObject bok;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            activeOnes.Push(transform.GetChild(i).gameObject);
        }
    }

    public void DecreaseHealth()
    {
        bok = activeOnes.Pop();
        bok.SetActive(false);
        deactiveOnes.Push(bok);

        if(activeOnes.Count <= 0)
        {
            Time.timeScale = 0;
        }
    }
    public void IncreaseHealth()
    {
        bok = deactiveOnes.Pop();
        bok.SetActive(true);
        activeOnes.Push(bok);
    }
}
