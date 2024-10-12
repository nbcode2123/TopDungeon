using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardIdleState : BaseState
{
    public WizardIdleState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
    {
        this.actor = actor;
        this.stateMachine = stateMachine;


    }
    public override void EnterState()
    {

        base.EnterState();
        Debug.Log("enter idlestate");


    }
    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("exit idlestate");

    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        Debug.Log(" idlestate");
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }
}
