using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_Reload : StatesInterface
{
    private BossReferences bossReferences;

    public BossState_Reload(BossReferences bossReferences)
    {
        this.bossReferences = bossReferences;
    }

    public void OnEnter()
    {
        Debug.Log("Start to reload");
        bossReferences.animator.SetFloat("cover", 1);
        bossReferences.animator.SetTrigger("reload");
    }

    public void OnExit()
    {
        Debug.Log("Stop to reload");
        bossReferences.animator.SetFloat("cover", 0);
        //bossReferences.animator.ResetTrigger("reload");
    }

    public void Tick()
    {

    }

    public Color GizmoColor()
    {
        return Color.gray;
    }
}
