using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : IState
{
    protected GameObject Actor;
    protected Animator Animator;

    public EnemyDeathState(GameObject actor, Animator animator)
    {
        Animator = animator;
        Actor = actor;

    }
    public virtual void EnterState()
    {
        Animator.Play("Death");

        // if (Actor.GetComponent<EnemyWeaponController>() != null)
        // {
        //     Actor.GetComponent<EnemyWeaponController>().GetWeapon().SetActive(false);

        // }
    }

    public virtual void ExitState()
    {
    }

    public virtual void FrameUpdate()
    {
    }

}
