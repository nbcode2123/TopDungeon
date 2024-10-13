using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallIdleState : BaseState
{
    public float counter;
    public EyeBallIdleState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            actor.GetComponent<MoveAround>().MoveRandom();
        }


    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }

}
