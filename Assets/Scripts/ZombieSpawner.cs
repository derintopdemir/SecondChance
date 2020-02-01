using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnZombie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(Random.Range(WaveController.Singleton.GetMinInterval(), WaveController.Singleton.GetMaxInterval()));
        if (WaveController.Singleton.CanZombieSpawn())
        {
            Debug.Log("Zombie terror has been released");
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        }
        StartCoroutine("SpawnZombie");
    }
}
