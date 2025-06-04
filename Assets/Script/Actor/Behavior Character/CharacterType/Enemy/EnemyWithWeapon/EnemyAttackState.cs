using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IState
{
    protected GameObject Actor;
    protected Animator Animator;
    protected Action OnAttack;

    public EnemyAttackState(GameObject actor, Animator animator)
    {
        Actor = actor;
        Animator = animator;
    }
    public virtual void EnterState()
    {
        RegisOnAttack(Actor.GetComponent<EnemyStateController>().AttackInvoke);
        Animator.Play("Move");

    }
    public void RegisOnAttack(Action callback)
    {
        OnAttack += callback;
    }
    public void UnRegisOnAttack(Action callback)
    {
        OnAttack -= callback;
    }

    public virtual void ExitState()
    {
        // throw new System.NotImplementedException();
        RegisOnAttack(Actor.GetComponent<EnemyStateController>().AttackInvoke);
        Actor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }

    public virtual void FrameUpdate()
    {
        // throw new System.NotImplementedException();
        OnAttack?.Invoke();
    }

}
