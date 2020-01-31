using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Fire : MonoBehaviour
{
    [SerializeField]
    LeanGameObjectPool leanObj;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("Player1"))
        {
            Transform parent = GameObject.FindGameObjectWithTag("Player1").transform;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet = Resources.Load("Bullet") as GameObject;
                LeanPool.Spawn(bullet,parent.position, Quaternion.identity);
                bullet.transform.position = new Vector3(0, 10, 0);
            }
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
            Transform parent = GameObject.FindGameObjectWithTag("Player2").transform;
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject bullet = Resources.Load("Bullet") as GameObject;
                LeanPool.Spawn(bullet,parent.position, Quaternion.identity);
                bullet.transform.position = new Vector3(0,10,0);
            }
        }
    }
}
