using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : AttackState
{
    public Action OnMovement;
    public PlayerMoveState(GameObject actor, StateMachine stateMachine, Animator animator) : base(actor, stateMachine, animator)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        OnMovement = actor.GetComponent<MovePlayer>().ControllActor;



    }

    public override void ExitState()
    {



    }

    public override void FrameUpdate()
    {
        OnMovement?.Invoke();

    }


}
