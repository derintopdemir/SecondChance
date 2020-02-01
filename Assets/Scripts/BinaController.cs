using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaController : MonoBehaviour
{
    public Buildings buildingInfo;

    private int health;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateResources());
        health = buildingInfo.buildingHealth;
        GetComponent<MeshFilter>().mesh = buildingInfo.mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UpdateResources()
    {
        yield return new WaitForSeconds(buildingInfo.interval);
        ResourceManager.Singleton.AddResource(buildingInfo.producing, buildingInfo.contribution);
        StartCoroutine(UpdateResources());
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(GetDamage(collision.gameObject));
        }
    }

    public IEnumerator GetDamage(GameObject attacker)
    {
        GetComponent<Rigidbody>().Sleep();
        health -= attacker.GetComponent<AgentController>().enemyInfo.damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            yield return new WaitForSeconds(2);
            GetComponent<Rigidbody>().WakeUp();
        }
    }
}
