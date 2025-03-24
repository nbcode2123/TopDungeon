using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private IAttack IAttack;
    private float AttackCounter;
    public AttackState(GameObject actor, StateMachine stateMachine, Animator animator) : base(actor, stateMachine, animator)
    {
        IAttack = actor.GetComponent<IAttack>();


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
