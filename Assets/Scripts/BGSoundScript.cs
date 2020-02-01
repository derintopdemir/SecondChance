using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("ses") == 0)
        {
            
            GetComponent<AudioSource>().Pause();
        }
        else if (PlayerPrefs.GetInt("ses") == 1)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    //Play Global
    private static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}