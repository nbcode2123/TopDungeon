using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{

    public AttackState(GameObject actor, StateMachine stateMachine, Animator animator) : base(actor, stateMachine, animator)
    {




    }

    public override void EnterState()
    {
        animator.Play("Attack");




    }

    public override void ExitState()
    {



    }

    public override void FrameUpdate()
    {

    }

}
