using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadElementsScript : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
