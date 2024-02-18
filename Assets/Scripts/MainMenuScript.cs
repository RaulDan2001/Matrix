using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void toLevelSelector()
    {
        SceneManager.LoadScene("LevelSelectorScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Succesfull");
        Application.Quit();
    }

}
