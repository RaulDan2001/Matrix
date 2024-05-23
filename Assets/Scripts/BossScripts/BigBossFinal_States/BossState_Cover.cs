using System;
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
        
        //avem inca o masina de stare
        stateMachine = new MachineState();

        //stari
        var bossShoot = new BossState_Shooting(bossReferences);
        var bossDelay = new BossState_Delay(1f);
        var bossReload = new BossState_Reload(bossReferences);

        //tranzitii
        At(bossShoot, bossReload, () => bossReferences.shooter.ShouldReload());
        At(bossReload, bossDelay, () => !bossReferences.shooter.ShouldReload());
        At(bossDelay, bossShoot, () => bossDelay.IsDone());

        //starea de inceput
        stateMachine.SetState(bossShoot);

        //Functii si conditii
        void At(StatesInterface from, StatesInterface to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(StatesInterface to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
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
        stateMachine.Tick();
    }

    public Color GizmoColor()
    {
        return stateMachine.GetGizmoColor();
    }

}
