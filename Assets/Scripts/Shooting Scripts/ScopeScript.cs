using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeScript : MonoBehaviour
{
    public Animator animator;
    private bool IsScoped = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            IsScoped = !IsScoped;
            animator.SetBool("IsScoped",IsScoped);
        }
    }

}