using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{
    public void ToStaticTrainScene()
    {
        SceneManager.LoadScene("StaticTargetScene");
    }
}
