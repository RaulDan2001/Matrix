using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_RunToCover : StatesInterface
{
    private BossReferences bossReferences;
    private CoverArea coverArea;

    public BossState_RunToCover(BossReferences bossReferences, CoverArea coverArea)
    {
        this.bossReferences = bossReferences;
        this.coverArea = coverArea;
    }

    public void OnEnter()
    {
        CoverScript nextCover = this.coverArea.GetRandomCover(bossReferences.transform.position);
        bossReferences.navMeshagent.SetDestination(nextCover.transform.position);
    }

    public void OnExit()
    {
        bossReferences.animator.SetFloat("Speed", 0f);
    }

    public void Tick()
    {
        bossReferences.animator.SetFloat("Speed", bossReferences.navMeshagent.desiredVelocity.sqrMagnitude);
    }

    public Color GizmoColor()
    {
        return Color.blue;
    }

    public bool HasArrivedAtDestination()
    {
        return bossReferences.navMeshagent.remainingDistance < 0.1f;
    }
}
