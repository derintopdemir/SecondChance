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
        StartCoroutine(GameStartSound());
    }

    IEnumerator GameStartSound()
    {
        playCur.clip = audios[0];
        playCur.Play();
        yield return new WaitForSeconds(playCur.clip.length);
        playCur.clip = audios[1];
        playCur.volume = 0.13f;
        playCur.Play();
    }
    public void Fire()
    {
        playCur.clip = audios[2];
        playCur.Play();
    }

    public void Wave(int index)
    {
        int nextSound = 2;
        if (index >= 5) nextSound++;
        playCur.clip = audios[nextSound];
        playCur.Play();
    }
}
