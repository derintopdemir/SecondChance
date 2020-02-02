using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    float timeScaleOld;

    public void Play()
    {
        FindObjectOfType<AudioManagerMenu>().Buton();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        FindObjectOfType<AudioManagerMenu>().Buton();
        Application.Quit();
    }

    public void BackToMenu()
    {
        FindObjectOfType<AudioManagerMenu>().Buton();
        SceneManager.LoadScene(0);
    }

    public void SoundOnOf(bool state)
    {
        Debug.Log(state);
        PlayerPrefs.SetInt("Sound", Convert.ToInt32(state));
    }
}
