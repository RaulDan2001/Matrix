using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject PauseCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (GamePaused && PauseCanvas != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void Resume()
    {
        if (GamePaused && PauseCanvas != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f; //oprim timpul din joc ca acesta sa ramana pe pauza
        GamePaused = true;

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");   
    }

    public void QuitFromPause()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
