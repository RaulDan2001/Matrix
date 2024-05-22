using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BigBossFinalScript : MonoBehaviour
{
    private BossReferences bossReferences;
    private MachineState stateMachine;

    void Start()
    {
        bossReferences = GetComponent<BossReferences>();

        stateMachine = new MachineState();

        //punem obiectele de tip cover in vector
        CoverArea coverArea = FindObjectOfType<CoverArea>();

        //Stari
        var runToCover = new BossState_RunToCover(bossReferences, coverArea);
        var delayAfterRun = new BossState_Delay(2f);
        var cover = new BossState_Cover(bossReferences);

        //Tranzitii
        At(runToCover, delayAfterRun, () => runToCover.HasArrivedAtDestination());
        At(delayAfterRun, cover, () => delayAfterRun.IsDone());

        //Stari de start
        stateMachine.SetState(runToCover);

        //Functii si conditii
        void At(StatesInterface from, StatesInterface to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(StatesInterface to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    private void Update()
    {
        stateMachine.Tick();
    }

    private void OnDrawGizmos()
    {
        if (stateMachine != null)
        {
            Gizmos.color = stateMachine.GetGizmoColor();
            Gizmos.DrawSphere(transform.position + Vector3.up * 3, 0.4f);
        }
    }
}
