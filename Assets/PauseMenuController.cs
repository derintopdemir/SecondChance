using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                FindObjectOfType<UıManager>().Resume();
            }
            else
            {
                FindObjectOfType<UıManager>().Pause();
            }
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
}
