using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UıManager : MonoBehaviour
{
    
    float timeScaleOld;
    [SerializeField]
    float triggerİçDelay;
    float triggerDelay;
    public bool triggerTetikle;

    public HealthBar barPlayer1, barPlayer2;
    private void Awake()
    {
        triggerDelay = triggerİçDelay;
    }

    private void Update()
    {
        if (!triggerTetikle) Reset();
        else if(triggerTetikle) { triggerDelay = triggerİçDelay; }
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
    public void DecreaseHealth(int healthAzaltmaŞartı, int player)
    {
        if(healthAzaltmaŞartı == 1)
        {
            if(player == 1)
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

    private void Reset()
    {
        triggerDelay -= Time.deltaTime;
        if (triggerDelay <= 0)
        {
            DecreaseHealth(2, 1);
            DecreaseHealth(2, 2);
        }
    }
}
