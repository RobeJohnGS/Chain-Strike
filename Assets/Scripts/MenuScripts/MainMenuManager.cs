using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] CurrentMenu currentMenu;
    [Header("UI Elements")]
    /*
     * UI Element 0: Click to continue text
     * UI Element 1: Main menu buttons
     */
    [SerializeField] GameObject[] uiElements;
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
                    currentMenu = CurrentMenu.menuSelection;
                    //Disable the click to continue text
                    EnableUIElement(uiElements[0], false);
                    //Enable the main buttons game object
                    EnableUIElement(uiElements[1], true);
                }
                break;
        }
    }

    public void SwitchMenu(int newMenu)
    {
        currentMenu = (CurrentMenu)newMenu;
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
