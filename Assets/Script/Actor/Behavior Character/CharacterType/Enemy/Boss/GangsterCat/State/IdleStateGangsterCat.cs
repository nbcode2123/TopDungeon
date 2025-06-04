using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateGangsterCat : State
{
    private GameObject Actor;
    private Animator Animator;
    public IdleStateGangsterCat(GameObject actor, Animator animator)
    {
        Actor = actor;
        Animator = animator;
    }

    public override void EnterState()
    {
        Animator.Play("Idle");

    }

}
