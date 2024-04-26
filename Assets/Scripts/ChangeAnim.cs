using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnim : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("StateID", Random.Range(0, 3));
    }
}

   
