using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public StateMachine stateMachine { set; get; }
    public BaseState IdleState { set; get; }
    public BaseState MoveState { set; get; }
    public BaseState DeathState { set; get; }
    public Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<IMovement>().OnStopMovement += ChangeToIdleState;
        gameObject.GetComponent<IMovement>().OnMovement += ChangeToMoveState;
        gameObject.GetComponent<PlayerDamageCalculator>().OnDeath += LockWhenDeath;
        gameObject.GetComponent<PlayerDamageCalculator>().OnDeath += ChangeToDeathState;


    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.CurrentState.FrameUpdate();

    }
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        stateMachine = new StateMachine();
        IdleState = new IdleState(gameObject, stateMachine, animator);
        MoveState = new MoveState(gameObject, stateMachine, animator);
        DeathState = new PlayerDeathState(gameObject, stateMachine, animator);
        stateMachine.Initialize(IdleState);
    }
    void OnEnable()
    {
        gameObject.GetComponent<IMovement>().OnStopMovement += ChangeToIdleState;
        gameObject.GetComponent<IMovement>().OnMovement += ChangeToMoveState;
        gameObject.GetComponent<PlayerDamageCalculator>().OnDeath += LockWhenDeath;
        gameObject.GetComponent<PlayerDamageCalculator>().OnDeath += ChangeToDeathState;

    }

    public void ChangeToIdleState()
    {
        stateMachine.ChangeState(IdleState);
    }

    public void ChangeToDeathState()
    {
        stateMachine.ChangeState(DeathState);
        Debug.Log("Player die ");

    }

    public void ChangeToMoveState()
    {
        stateMachine.ChangeState(MoveState);

    }
    private void OnDestroy()
    {
        gameObject.GetComponent<IMovement>().OnStopMovement -= ChangeToIdleState;
        gameObject.GetComponent<IMovement>().OnMovement -= ChangeToMoveState;
        gameObject.GetComponent<PlayerDamageCalculator>().OnDeath -= ChangeToDeathState;
        gameObject.GetComponent<PlayerDamageCalculator>().OnDeath -= LockWhenDeath;

    }
    private void OnDisable()
    {
        gameObject.GetComponent<IMovement>().OnStopMovement -= ChangeToIdleState;
        gameObject.GetComponent<IMovement>().OnMovement -= ChangeToMoveState;
        gameObject.GetComponent<PlayerDamageCalculator>().OnDeath -= ChangeToDeathState;
        gameObject.GetComponent<PlayerDamageCalculator>().OnDeath -= LockWhenDeath;

    }
    public void LockWhenDeath()
    {
        gameObject.GetComponent<IMovement>().OnStopMovement -= ChangeToIdleState;
        gameObject.GetComponent<IMovement>().OnMovement -= ChangeToMoveState;

    }



}
