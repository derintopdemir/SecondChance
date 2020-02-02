using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMenuController : MonoBehaviour
{
    public GameObject deathMenu, winPicture, LosePicture;

    public void Death()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0.1f;
        LosePicture.SetActive(true);
    }

    public void Won()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0.1f;
        winPicture.SetActive(true);
    }
}
