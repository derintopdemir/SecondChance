using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningRobotsParent : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Doğur());
    }

    IEnumerator Doğur()
    {

        for (int i = 0; i < transform.childCount;)
        {

            transform.GetChild(i).gameObject.SetActive(true);

            yield return new WaitForSeconds(.666f);
            i++;
        }
    }
}
