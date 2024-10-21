using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracularStates : MonoBehaviour
{
    public StateMachine stateMachine;
    public DracularIdleState IdleState;
    public DracularMoveState MoveState;
    void Awake()
    {
        stateMachine = new StateMachine();
        IdleState = new DracularIdleState(gameObject, stateMachine);
        MoveState = new DracularMoveState(gameObject, stateMachine);

        stateMachine.Initialize(IdleState);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckConditionToChangeState();

    }
    public void CheckConditionToChangeState()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            stateMachine.ChangeState(MoveState);


        }
        else
        {
            stateMachine.ChangeState(IdleState);
        }

    }
}
