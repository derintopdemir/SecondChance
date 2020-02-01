using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    private static WaveController singleton;
    public static WaveController Singleton { get { if (singleton == null) singleton = FindObjectOfType<WaveController>(); return singleton; } }

    public Text waveTimerText;
    public GameObject waveTimerPanel;

    [Serializable]
    public struct WaveInfo
    {
        public int minSpawnInterval;
        public int maxSpawnInterval;
        public int zombieCount;
        public int DownTime;
    }

    [SerializeField]
    public List<WaveInfo> waves;

    private int currentWave = 0, currentZombies = 0;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
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
        if(waves.Count > currentWave && currentZombies < waves[currentWave].zombieCount)
        {
            currentZombies += 1;
            return true;
        }
        else
        {
            if(!waveTimerPanel.activeSelf && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                StartCoroutine("WaveSwitch");
        }
        return false;
    }

    public IEnumerator WaveSwitch()
    {
        waveTimerPanel.SetActive(true);
        for (int i = waves[currentWave].DownTime; i >= 0; i--)
        {
            waveTimerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        currentWave += 1;
        waveTimerPanel.SetActive(false);
    }
}
