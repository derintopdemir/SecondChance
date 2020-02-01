using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Stack<GameObject> ob = new Stack<GameObject>();
    GameObject bok;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            ob.Push(transform.GetChild(i).gameObject);
            Debug.Log("Girdim amk");
        }
    }

    public void DecreaseHealth()
    {
        bok = ob.Pop();
        bok.SetActive(false);
    }
    public void IncreaseHealth()
    {
        ob.Push(bok);
    }
}
