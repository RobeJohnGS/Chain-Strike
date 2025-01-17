using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] bool editorMode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        if (editorMode)
        {
            EditorApplication.ExitPlaymode();
        }
    }
}
