using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IAttack))]
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
    void OnEnable()
    {
        // AttackRangeCollider.GetComponent<IColliderTrigger>().OnStayTrigger += ChangeToAttackState;
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnEnterTrigger += ChangeToAttackState;

        AttackRangeCollider.GetComponent<IColliderTrigger>().OnExitTrigger += ChangeToIdleState;
        gameObject.GetComponent<DamageCaculator>().OnDeath += LockDeathState;
        gameObject.GetComponent<DamageCaculator>().OnDeath += ChangeToDeathState;
    }
    void OnDestroy()
    {
        // AttackRangeCollider.GetComponent<IColliderTrigger>().OnStayTrigger -= ChangeToAttackState;
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnEnterTrigger -= ChangeToAttackState;
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangeToIdleState;
        gameObject.GetComponent<DamageCaculator>().OnDeath -= LockDeathState;
        gameObject.GetComponent<DamageCaculator>().OnDeath -= ChangeToDeathState;

    }
    public void ChangetoAttackState()
    {
        stateMachine.ChangeState(AttackState);
    }
    public void ChangeToIdleState()
    {
        stateMachine.ChangeState(IdleState);
    }
    public void ChangeToDeathState()
    {
        stateMachine.ChangeState(DeathState);
    }

    public void ChangeToAttackState()
    {
        stateMachine.ChangeState(AttackState);
    }
    public void ChangeToDamageState()
    {
        stateMachine.ChangeState(DamageState);
    }
    public void LockDeathState()
    {
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnEnterTrigger -= ChangeToAttackState;
        AttackRangeCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangeToIdleState;

    }

}
