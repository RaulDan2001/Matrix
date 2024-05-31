using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1End : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene("CongratsScene");
    }
}
