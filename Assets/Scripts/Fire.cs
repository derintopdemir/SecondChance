using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Fire : MonoBehaviour
{
    [SerializeField]
    LeanGameObjectPool leanObj;
    [SerializeField]
    Transform p1fire;


    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("Player1"))
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet = Resources.Load("Bullet") as GameObject;
                leanObj.Spawn(p1fire.position, Quaternion.identity);
                bullet.transform.position = new Vector3(0, 10, 0);
                leanObj.Despawn(bullet, 2f);
            }
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
            Transform parent = GameObject.FindGameObjectWithTag("Player2").transform;
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject bullet = Resources.Load("Bullet") as GameObject;
                leanObj.Spawn(p1fire.position, Quaternion.identity);
                bullet.transform.position = new Vector3(0,10,0);
                leanObj.Despawn(bullet, 2f);
            }
        }
    }
}
