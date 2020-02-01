using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UıManager : MonoBehaviour
{
    
    float timeScaleOld;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        timeScaleOld = Time.timeScale;
        Time.timeScale = 0;
    }

    public  void Resume()
    {
        Time.timeScale = timeScaleOld;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void DecreaseHealth(int healthAzaltmaŞartı)
    {
        if(healthAzaltmaŞartı == 1)
        {
            FindObjectOfType<HealthBar>().DecreaseHealth();
        }
        else if (healthAzaltmaŞartı == 2)
        {
            FindObjectOfType<HealthBar>().DecreaseHealth();
        }
    }
    public void IncreaseHealth()
    {
        FindObjectOfType<HealthBar>().IncreaseHealth();
    }

}
