using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharactorStats))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IAttack))]


public class MeleeEnemyStateController : MonoBehaviour, IAttackState, IIdleState, IMoveState, IDeathState
{
    public StateMachine stateMachine { set; get; }
    public BaseState AttackState { set; get; }
    public BaseState IdleState { set; get; }
    public BaseState MoveState { set; get; }
    public BaseState DeathState { set; get; }
    public BaseState DamageState;
    public BaseState ChaseState;
    private Animator animator;
    public GameObject AttackCollider;
    public GameObject ChaseCollider;
    public string State;
    private GameObject Target;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        stateMachine = new StateMachine();
        AttackState = new AttackState(gameObject, stateMachine, animator);
        IdleState = new IdleState(gameObject, stateMachine, animator);
        MoveState = new MoveState(gameObject, stateMachine, animator);
        DeathState = new DeathState(gameObject, stateMachine, animator);
        DamageState = new DamageState(gameObject, stateMachine, animator);
        stateMachine.Initialize(IdleState);


    }
    public virtual void OnEnable()
    {
        AttackCollider.GetComponent<IColliderTrigger>().OnEnterTrigger += ChangeToAttackState;
        ChaseCollider.GetComponent<IColliderTrigger>().OnEnterTrigger += ChangeToMoveState;

        AttackCollider.GetComponent<IColliderTrigger>().OnExitTrigger += ChangToChaseState;
        ChaseCollider.GetComponent<IColliderDetectObject>().DectectObject += ChangeToChaseState;
        ChaseCollider.GetComponent<IColliderTrigger>().OnExitTrigger += ChangeToIdleState;

        gameObject.GetComponent<DamageCaculator>().OnDeath += ChangeToDeathState;











    }
    public void OnDestroy()
    {
        AttackCollider.GetComponent<IColliderTrigger>().OnEnterTrigger -= ChangeToAttackState;
        ChaseCollider.GetComponent<IColliderDetectObject>().DectectObject -= ChangeToChaseState;

        AttackCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangToChaseState;
        ChaseCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangeToIdleState;
        ChaseCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangeToIdleState;

        gameObject.GetComponent<DamageCaculator>().OnDeath -= ChangeToDeathState;



    }
    private void Update()
    {
        stateMachine.CurrentState.FrameUpdate();
    }
    public void SelectState(BaseState state)
    {
        stateMachine.ChangeState(state);

    }
    public void ChangeToAttackState()
    {
        stateMachine.ChangeState(AttackState);
        State = "Attack";

    }
    public void ChangeToDamageState()
    {
        stateMachine.ChangeState(DamageState);
        State = "Damage";
    }

    public void ChangeToChaseState(GameObject target)
    {
        Target = target;
        ChaseState = new ChaseState(gameObject, stateMachine, animator, target);
        stateMachine.ChangeState(ChaseState);
        State = "Chase";
    }
    public void ChangToChaseState()
    {
        ChaseState = new ChaseState(gameObject, stateMachine, animator, Target);
        stateMachine.ChangeState(ChaseState);
        State = "Chase";

    }
    public void ChangeToIdleState()
    {
        stateMachine.ChangeState(IdleState);
    }

    public void ChangeToDeathState()
    {
        stateMachine.ChangeState(DeathState);

    }

    public void ChangeToMoveState()
    {
        stateMachine.ChangeState(MoveState);

    }
    public void LockDeathState()
    {
        AttackCollider.GetComponent<IColliderTrigger>().OnEnterTrigger -= ChangeToAttackState;
        ChaseCollider.GetComponent<IColliderDetectObject>().DectectObject -= ChangeToChaseState;

        AttackCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangToChaseState;
        ChaseCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangeToIdleState;
        ChaseCollider.GetComponent<IColliderTrigger>().OnExitTrigger -= ChangeToIdleState;

    }



}
