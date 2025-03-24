using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    public MoveState(GameObject actor, StateMachine stateMachine, Animator animator) : base(actor, stateMachine, animator)
    {
    }

    public override void EnterState()
    {
        animator.Play("Move");

    }

    public override void ExitState()
    {

    }

    public override void FrameUpdate()
    {


    }

}
