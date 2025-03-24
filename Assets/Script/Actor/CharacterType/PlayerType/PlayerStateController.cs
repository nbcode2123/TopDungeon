using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour, IIdleState, IMoveState, IDeathState
{
    public StateMachine stateMachine { set; get; }
    public BaseState IdleState { set; get; }
    public BaseState MoveState { set; get; }
    public BaseState DeathState { set; get; }
    public Animator animator;




    // Start is called before the first frame update
    void Start()
    {

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
        DeathState = new DeathState(gameObject, stateMachine, animator);
        stateMachine.Initialize(IdleState);
    }
    void OnEnable()
    {
        gameObject.GetComponent<IMovement>().OnStopMovement += ChangeToIdleState;
        gameObject.GetComponent<IMovement>().OnMovement += ChangeToMoveState;
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
}
