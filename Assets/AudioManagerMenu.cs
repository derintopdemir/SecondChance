using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenu : MonoBehaviour
{
    public List<AudioClip> audios;
    public AudioSource playCur;

    private void Start()
    {
        playCur = GetComponent<AudioSource>();
        playCur.enabled = Convert.ToBoolean(PlayerPrefs.GetInt("Sound", 1));
        playCur.clip = audios[0];
        playCur.Play();
    }

    private void Update()
    {
        playCur = GetComponent<AudioSource>();
        playCur.enabled = Convert.ToBoolean(PlayerPrefs.GetInt("Sound", 1));
        MainMusic();
    }

    private void MainMusic()
    {
        playCur.clip = audios[0];
        if (PlayerPrefs.GetInt("Sound", 1) == 0)
        {
            playCur.enabled = false;
        } else if(PlayerPrefs.GetInt("Sound", 1) == 1){
            playCur.enabled = true;
            playCur.playOnAwake = true;
        }
    }
    public void Buton()
    {
        playCur.clip = audios[1];
        playCur.Play();
    }
}
