using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using Cinemachine;
using System.Linq;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Animator menuAnimator;
    [SerializeField] CurrentMenu currentMenu;
    [Header("Cameras")]
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject customizeCamera;
    [Header("UI Elements")]
    [SerializeField] GameObject clickToContinueTxt;
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] GameObject customizeCharacterMenu;
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
                    SwitchMenu(1);
                    
                }
                break;
        }
    }

    public void SwitchMenu(int newMenu)
    {
        //Switch to the new menu using ints
        currentMenu = (CurrentMenu)newMenu;

        switch (currentMenu)
        {
            case CurrentMenu.clickToStart:
                
                break;
            case CurrentMenu.levelSelect:

                break;
            case CurrentMenu.customize:

                break;
            case CurrentMenu.settings:

                break;
        }
    }

    private void SelectCustomizeCharacter()
    {
        currentMenu = CurrentMenu.customize;
        EnableUIElement(customizeCharacterMenu, true);
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
