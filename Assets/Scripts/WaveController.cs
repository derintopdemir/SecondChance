using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private static WaveController singleton;
    public static WaveController Singleton { get { if (singleton == null) singleton = new WaveController(); return singleton; } }

    [Serializable]
    private struct WaveInfo
    {
        public int minSpawnInterval;
        public int maxSpawnInterval;
        public int zombieCount;
        public int DownTime;
    }

    [SerializeField]
    private List<WaveInfo> waves;

    private int currentWave = 0, currentZombies = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMinInterval()
    {
        if(waves.Count > currentWave)
        {
            return waves[currentWave].minSpawnInterval;
        }
        return waves[waves.Count - 1].minSpawnInterval;
    }

    public int GetMaxInterval()
    {
        if (waves.Count > currentWave)
        {
            return waves[currentWave].maxSpawnInterval;
        }
        return waves[waves.Count - 1].maxSpawnInterval;
    }

    public int GetZombieCount()
    {
        if (waves.Count > currentWave)
        {
            return waves[currentWave].zombieCount;
        }
        return waves[waves.Count - 1].zombieCount;
    }

    public bool CanZombieSpawn()
    {
        if(waves.Count > currentWave && currentZombies < waves[currentZombies].zombieCount)
        {
            currentZombies += 1;
            return true;
        }
        return false;
    }

    public IEnumerator WaveSwitch()
    {
        yield return new WaitForSeconds(waves[currentWave].DownTime);
        currentWave += 1;
    }
}
