using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour 
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimJump()
    {
        animator.Play("StartJump");
    }

    public void AnimDie()
    {
        animator.Play("Die");
    }

    public void AnimRun()
    {
        animator.Play("Run");
    }
}
