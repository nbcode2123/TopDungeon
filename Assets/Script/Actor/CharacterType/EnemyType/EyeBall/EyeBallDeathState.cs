using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallDeathState : BaseState
{
    public EyeBallDeathState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
    {
        this.actor = actor;
        this.stateMachine = stateMachine;


    }
    public override void EnterState()
    {

        base.EnterState();



    }
    public override void ExitState()
    {
        base.ExitState();


    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();

    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }
}
