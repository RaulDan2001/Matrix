using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState_Shooting : StatesInterface
{
    private BossReferences bossReferences;
    private Transform player;

    public BossState_Shooting(BossReferences bossReferences)
    {
        this.bossReferences = bossReferences;
    }

    public void OnEnter()
    {
        Debug.Log("Start to shoot");
        player = GameObject.FindWithTag("Player").transform;
    }

    public void OnExit()
    {
        Debug.Log("Stop to shoot");
        bossReferences.animator.SetBool("shooting", false);
        player = null;
    }

    public void Tick()
    {
        if (player != null)
        {
            //Tintim jucatorul
            Vector3 lookPos = player.position - bossReferences.transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            bossReferences.transform.rotation = Quaternion.Slerp(bossReferences.transform.rotation, rotation, 0.2f);

            //Alegem daca trage sau se ascunde
            bossReferences.animator.SetBool("shooting", true);
        }
    }

    public Color GizmoColor()
    {
        return Color.red;
    }
}
