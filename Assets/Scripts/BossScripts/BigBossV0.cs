using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossV0 : MonoBehaviour
{
    public Transform target;

    private BossReferences bossReferences;

    private float pathUpdateDeadLine;

    private float shootingDistance;

    private void Awake()
    {
        bossReferences = GetComponent<BossReferences>();
    }
    
    void Start()
    {
        shootingDistance = bossReferences.navMeshagent.stoppingDistance;
    }

    
    void Update()
    {
        if (target != null) 
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;

            if (inRange) 
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }

            bossReferences.animator.SetBool("shooting", inRange);
        }
        bossReferences.animator.SetFloat("Speed", bossReferences.navMeshagent.desiredVelocity.sqrMagnitude);
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadLine)
        {
            Debug.Log("Updating Path");
            pathUpdateDeadLine = Time.time + bossReferences.pathUpdateDelay;
            bossReferences.navMeshagent.SetDestination(target.position);
        }
    }
}
