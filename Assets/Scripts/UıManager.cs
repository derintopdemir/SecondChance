using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UıManager : MonoBehaviour
{

    float timeScaleOld;


    public HealthBar barPlayer1, barPlayer2, hungerP1, hungerP2, batteryP1, batteryP2;

    public void Start()
    {
        StartCoroutine(DecreaseHunger(1));
        StartCoroutine(DecreaseHunger(2));
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        timeScaleOld = Time.timeScale;
        Time.timeScale = 0;
    }

    public void Resume()
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

    public IEnumerator DecreaseHunger(int player)
    {
        if (player == 1)
        {
            hungerP1.DecreaseHealth();
        }
        else
        {
            hungerP2.DecreaseHealth();
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(DecreaseHunger(player));
    }

    public void IncreaseHunger(int player)
    {
        if (player == 1)
        {
            hungerP1.IncreaseHealth();
        }
        else
        {
            hungerP2.IncreaseHealth();
        }
    }

    public void DecreaseHealth(int healthAzaltmaŞartı, int player)
    {
        if (healthAzaltmaŞartı == 1)
        {
            if (player == 1)
            {
                barPlayer1.DecreaseHealth();
            }
            else
            {
                barPlayer2.DecreaseHealth();
            }
        }
        else if (healthAzaltmaŞartı == 2)
        {
            if (player == 1)
            {
                barPlayer1.DecreaseHealth();
            }
            else
            {
                barPlayer2.DecreaseHealth();
            }
        }
    }

    public void IncreaseHealth(int player)
    {
        if (player == 1)
        {
            barPlayer1.IncreaseHealth();
        }
        else
        {
            barPlayer2.IncreaseHealth();
        }
    }
}
