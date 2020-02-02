using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> audios;
    public AudioSource playCur;

    private void Awake()
    {
        playCur = GetComponent<AudioSource>();
        playCur.enabled = Convert.ToBoolean(PlayerPrefs.GetInt("Sound", 1));
    }

    public void Walk(bool trigger)
    {
        if (trigger)
        {
            playCur.clip = audios[0];
            playCur.Play();
            playCur.loop = true;
        }
        else if (!trigger)
        {
            playCur.clip = audios[0];
            playCur.Stop();
            playCur.loop = false;
        }
    }
    public void Fire()
    {
        playCur.clip = audios[1];
        playCur.Play();
    }
    public void Wave(int index)
    {
        int nextSound = 2;
        if (index >= 5) nextSound++;
        playCur.clip = audios[nextSound];
        playCur.Play();
    }
    public void Buton(int index)
    {
        playCur.clip = audios[index];
        playCur.Play();
    }
}
