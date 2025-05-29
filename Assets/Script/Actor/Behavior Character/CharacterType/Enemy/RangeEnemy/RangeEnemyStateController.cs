using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyStateController : MonoBehaviour
{
    private StateMachine stateMachine;
    private BaseState IdleState;
    private BaseState AttackState;
    private BaseState DamageState;
    private BaseState DeathState;
    private Animator animator;
    public GameObject AttackRangeCollider;
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        stateMachine = new StateMachine();
        IdleState = new IdleState(gameObject, stateMachine, animator);
        AttackState = new AttackState(gameObject, stateMachine, animator);
        DamageState = new DamageState(gameObject, stateMachine, animator);
        DeathState = new DeathState(gameObject, stateMachine, animator);
        stateMachine.Initialize(IdleState);



    }
    void Update()
    {
        stateMachine.CurrentState.FrameUpdate();
    }
    public virtual void OnEnable()
    {
        // AttackRangeCollider.GetComponent<IColliderTrigger>().OnStayTrigger += ChangeToAttackState;
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnEnterTrigger += ChangeToAttackState;

        AttackRangeCollider.GetComponent<IColliderTrigger>().OnExitTrigger += ChangeToIdleState;
        gameObject.GetComponent<DamageCalculator>().OnDeath += LockDeathState;
        gameObject.GetComponent<DamageCalculator>().OnDeath += ChangeToDeathState;
    }
    public virtual void OnDestroy()
    {
        // AttackRangeCollider.GetComponent<IColliderTrigger>().OnStayTrigger -= ChangeToAttackState;
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnEnterTrigger -= ChangeToAttackState;
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangeToIdleState;
        gameObject.GetComponent<DamageCalculator>().OnDeath -= LockDeathState;
        gameObject.GetComponent<DamageCalculator>().OnDeath -= ChangeToDeathState;

    }
    public virtual void ChangeToAttackState()
    {
        stateMachine.ChangeState(AttackState);
    }
    public virtual void ChangeToIdleState()
    {
        stateMachine.ChangeState(IdleState);
    }
    public virtual void ChangeToDeathState()
    {
        stateMachine.ChangeState(DeathState);
    }


    public virtual void ChangeToDamageState()
    {
        stateMachine.ChangeState(DamageState);
    }
    public virtual void LockDeathState()
    {
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnEnterTrigger -= ChangeToAttackState;
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangeToIdleState;

    }

}
