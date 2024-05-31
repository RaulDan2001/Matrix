using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class BossReferences : MonoBehaviour
{
    public NavMeshAgent navMeshagent;
    public Animator animator;
    public BossShoting shooter;
    public TargetBoss targetBoss;

    [Header("Stats")]

    public float pathUpdateDelay = 0.2f;

    private void Awake()
    {
        navMeshagent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        shooter = GetComponent<BossShoting>();
    }
}
