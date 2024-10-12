using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttackState : BaseState
{
     public WizardAttackState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
    {
        this.actor = actor;
        this.stateMachine = stateMachine;


    }
    public override void EnterState()
    {

        base.EnterState();
        Debug.Log("enter attackstate");


    }
    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("exit attackstate");

    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        Debug.Log(" attackstate");
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }
}
