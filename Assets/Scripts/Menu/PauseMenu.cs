using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Skyrim2.0/Menus/Pause")]

public class PauseMenu : MonoBehaviour
{
    public static bool paused;
    public static bool showOptions;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    
    void Start()
    {
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TogglePause();
        }
    }

    public void ToggleOptions()
    {
        if(showOptions)
        {
            showOptions = false;
        }
        else
        {
            showOptions = true;
            pauseMenu.SetActive(showOptions);
        }
        optionsMenu.SetActive(showOptions);
    }

    public void TogglePause()
    {
        if (paused && !showOptions && !Inventory.showInv)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 1;
            paused = false;
            pauseMenu.SetActive(false);
        }
        else if (paused && !showOptions)
        {
            ToggleOptions();
            pauseMenu.SetActive(true);
        }
        else if(paused && !showOptions && Inventory.showInv)
        {
            paused = false;
            pauseMenu.SetActive(false);
        }
        else 
        {
            Time.timeScale = 0;
            paused = true;
            pauseMenu.SetActive(true);
        }
    }

   
    

   
}
