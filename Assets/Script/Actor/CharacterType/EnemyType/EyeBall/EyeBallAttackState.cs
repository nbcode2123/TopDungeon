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
        actor.GetComponent<Animator>().SetBool("isAttack", true);
    }
    public override void ExitState()
    {
        base.ExitState();
        actor.GetComponent<Animator>().SetBool("isAttack", false);
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        // Debug.Log(attackCounter);

    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();

    }



}
