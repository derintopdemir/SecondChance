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

    private void Reset()
    {
        triggerDelay -= Time.deltaTime;
        if (triggerDelay <= 0)
        {
            DecreaseHealth(2);
        }
    }
}
