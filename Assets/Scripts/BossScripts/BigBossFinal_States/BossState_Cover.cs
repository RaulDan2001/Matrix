using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_Cover : StatesInterface
{
    private BossReferences bossReferences;
    private MachineState stateMachine;

    public BossState_Cover(BossReferences bossReferences)
    {
        this.bossReferences = bossReferences;
        // TODO: Inca o masina de stare
    }

    public void OnEnter()
    {
        bossReferences.animator.SetBool("combat", true);
    }

    public void OnExit()
    {
        bossReferences.animator.SetBool("combat", false);
    }

    public void Tick()
    {

    }

    public Color GizmoColor()
    {
        return Color.gray;
    }

}
