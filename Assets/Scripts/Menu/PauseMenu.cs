using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsPanel;

    public bool isPaused = false;

    public void Options()
    {
        if (GameObject.Find("Options")); 
        {
            
        }
    }
    
    public void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Pause();
        }
    }

    void OptionToggle()
    {

    }

    private void Start()
    {
        Time.timeScale = 1;

        pauseMenu = GameObject.Find("Pause");
        //optionsPanel = 

        //pauseMenu.SetActive(false);
    }
}
