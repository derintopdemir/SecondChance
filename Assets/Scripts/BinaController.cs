using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaController : MonoBehaviour
{
    public Buildings buildingInfo;

    [SerializeField]
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(GetDamage(other.gameObject));
        }
    }

    private bool canGetDamage = true;

    public IEnumerator GetDamage(GameObject attacker)
    {
        if (canGetDamage)
        {
            canGetDamage = false;
            health -= attacker.GetComponent<AgentController>().enemyInfo.damage;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                yield return new WaitForSeconds(2);
                canGetDamage = true;
            }
        }
    }
}
