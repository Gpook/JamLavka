using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("idAtack", Random.Range(0, 3));
    }
}
