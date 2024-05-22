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

    public void ToMovingEnemyScript()
    {
        SceneManager.LoadScene("MovingEnemyScene");
    }

    public void ToBossFightScene()
    {
        SceneManager.LoadScene("BossFightScene");
    }
}
