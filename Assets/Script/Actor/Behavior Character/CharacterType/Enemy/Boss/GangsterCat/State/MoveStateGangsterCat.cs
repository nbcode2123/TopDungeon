using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStateGangsterCat : State
{
    private GameObject Actor;
    private Animator Animator;
    public MoveStateGangsterCat(GameObject actor, Animator animator)
    {
        Actor = actor;
        Animator = animator;
    }
    public override void EnterState()
    {
        base.EnterState();
        Animator.Play("Move");
        Actor.GetComponent<MoveStateExecution>().SetPlayer(Actor.GetComponent<StateControllerGangsterCat>().GetTargetPlayer());

    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        Actor.GetComponent<MoveStateExecution>().Move();

    }
    public override void ExitState()
    {
        base.ExitState();
        Actor.GetComponent<MoveStateExecution>().StopMovement();

    }



}
