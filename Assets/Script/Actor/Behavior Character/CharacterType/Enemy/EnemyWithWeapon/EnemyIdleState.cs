using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState
{
    private GameObject Actor;
    private Animator Animator;

    public EnemyIdleState(GameObject actor, Animator animator)
    {
        Actor = actor;
        Animator = animator;
    }
    public void EnterState()
    {
        Animator.Play("Idle");
        Actor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;


    }

    public void ExitState()
    {
    }

    public void FrameUpdate()
    {
    }


}
