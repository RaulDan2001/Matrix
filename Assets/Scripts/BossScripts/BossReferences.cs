using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class BossRefernces : MonoBehaviour
{
    public NavMeshAgent navMeshagent;
    public Animator animator;

    private void Awake()
    {
        navMeshagent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
}
