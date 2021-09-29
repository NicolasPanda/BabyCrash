using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.


public class MenuManage : MonoBehaviour
{
    public enum MenuType { Main, Dead, Pause}
    public MenuType  currentMenu = MenuType.Main;
    
    public Canvas mainMenu;

    public Canvas deadMenu;

    public Canvas pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeCurrentMenu(currentMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentMenu == MenuType.Pause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && currentMenu == MenuType.Dead)
        {
            ResetScene();
        }

        if (Player.dead)
        {
            ChangeCurrentMenu(MenuType.Dead);
            GameManager.PauseGame();
        }

    }

    public void PauseGame()
    {
        ChangeCurrentMenu(MenuType.Pause);
        GameManager.PauseGame();
    }

    public void ResumeGame()
    {
        ChangeCurrentMenu(MenuType.Main);
        GameManager.ResumeGame();
    }

    public void ResetScene()
    {
        ChangeCurrentMenu(MenuType.Main);
        GameManager.ResumeGame();
        GameManager.ResetScene();
    }

    private void ChangeCurrentMenu(MenuType menu)
    {
        switch (menu)
        {
            case MenuType.Main:
                currentMenu = MenuType.Main;
                mainMenu.enabled = true;
                deadMenu.enabled = false;
                pauseMenu.enabled = false;
                break;
            case MenuType.Dead:
                currentMenu = MenuType.Dead;
                mainMenu.enabled = false;
                deadMenu.enabled = true;
                pauseMenu.enabled = false;
                break;
            case MenuType.Pause:
                currentMenu = MenuType.Pause;
                mainMenu.enabled = false;
                deadMenu.enabled = false;
                pauseMenu.enabled = true;
                break;
            default:
                currentMenu = MenuType.Main;
                mainMenu.enabled = true;
                deadMenu.enabled = false;
                pauseMenu.enabled = false;
                break;
        }
    }
}
