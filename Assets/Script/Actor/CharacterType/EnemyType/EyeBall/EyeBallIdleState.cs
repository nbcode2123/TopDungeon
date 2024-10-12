using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallIdleState : BaseState
{
    public Vector3 markPosition;

    public EyeBallIdleState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
    {
        this.actor = actor;
        this.stateMachine = stateMachine;


    }
    public override void EnterState()
    {

        base.EnterState();
        markPosition = actor.gameObject.GetComponent<EyeBall>().posStart;



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
    public void MoveAroundPosition()
    {




    }
}
