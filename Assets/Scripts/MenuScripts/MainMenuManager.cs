using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using Cinemachine;
using System.Linq;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Animator menuAnimator;
    [SerializeField] CurrentMenu currentMenu;
    [Header("Cameras")]
    [SerializeField, Tooltip("Main Camera: 0\nLevel Select Camera: 1\nCustomizeCamera: 2\nSettings Camera: 3")] CinemachineVirtualCamera[] cameras;
    [Header("UI Elements")]
    [SerializeField] GameObject clickToContinueTxt;
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] GameObject customizeCharacterMenu;
    [SerializeField] GameObject lvlSelectMenu;
    enum CurrentMenu
    {
        clickToStart,
        menuSelection,
        levelSelect,
        customize,
        settings
    }

    private void Start()
    {
        currentMenu = CurrentMenu.clickToStart;
    }

    private void Update()
    {
        switch (currentMenu)
        {
            case CurrentMenu.clickToStart:
                if (Input.anyKeyDown)
                {
                    //Switch to menuSelection menu
                    Debug.Log("Start Game");
                    SwitchMenu(1);
                    
                }
                break;
            case CurrentMenu.menuSelection:
                break;
            case CurrentMenu.levelSelect:
                break;
            case CurrentMenu.customize:

                break;
            case CurrentMenu.settings:

                break;
        }
    }

    public void SwitchMenu(int newMenu)
    {
        //Disables all menus in the scene
        DisableMenus();
        //Switch to the new menu using ints
        currentMenu = (CurrentMenu)newMenu;
        Debug.Log("Switching to " + (CurrentMenu)newMenu + " menu");

        switch (currentMenu)
        {
            case CurrentMenu.clickToStart:
                //Shouldn't be switching to this menu
                break;
            case CurrentMenu.menuSelection:
                //Switches the camera if needed
                SwitchCamera(0);
                //enables the main menu buttons
                mainMenuButtons.SetActive(true);
                //Starts the main menu button animation
                menuAnimator.SetTrigger("MainButtons");
                break;
            case CurrentMenu.levelSelect:
                SwitchCamera(1);
                lvlSelectMenu.SetActive(true);
                break;
            case CurrentMenu.customize:

                break;
            case CurrentMenu.settings:

                break;
        }
    }

    private void SwitchCamera(int camera)
    {
        foreach(CinemachineVirtualCamera vCams in cameras)
        {
            vCams.Priority = 10;
        }
        cameras[camera].Priority = 11;
    }

    private void DisableMenus()
    {
        clickToContinueTxt.SetActive(false);
        mainMenuButtons.SetActive(false);
        customizeCharacterMenu.SetActive(false);
        lvlSelectMenu.SetActive(false);
        Debug.Log("Menus Disabled");
    }

    private void EnableUIElement(GameObject uiOb, bool enable)
    {
        uiOb.SetActive(enable);
    }

    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
