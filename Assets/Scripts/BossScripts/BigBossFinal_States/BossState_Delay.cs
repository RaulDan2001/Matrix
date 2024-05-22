using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_Delay : StatesInterface
{
    private float waitForSeconds;
    private float deadLine;

    public BossState_Delay(float waitForSeconds)
    {
        this.waitForSeconds = waitForSeconds;
    }

    public void OnEnter()
    {
        deadLine = Time.time + waitForSeconds;
    }

    public void OnExit()
    {
        Debug.Log("AsteptareBoss la iesire");
    }

    public void Tick()
    {

    }

    public Color GizmoColor()
    {
        return Color.white;
    }

    public bool IsDone()
    {
        return Time.time >= deadLine;
    }
}
