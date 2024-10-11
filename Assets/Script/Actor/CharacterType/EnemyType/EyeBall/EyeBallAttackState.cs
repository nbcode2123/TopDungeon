using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallAttackState : BaseState
{
    public float attackCounter;
    public GameObject player;

    public EyeBallAttackState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
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
        attackCounter += Time.deltaTime;

    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }


}
