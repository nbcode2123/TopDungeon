using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiStates : MonoBehaviour
{
    public StateMachine stateMachine;
    public SamuraiRunState RunState;
    public SamuraiIdleState IdleState;
    public SamuraiAttackState AttackState;

    void Awake()
    {
        stateMachine = new StateMachine();
        IdleState = new SamuraiIdleState(gameObject, stateMachine);
        AttackState = new SamuraiAttackState(gameObject, stateMachine);
        RunState = new SamuraiRunState(gameObject, stateMachine);

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
        stateMachine.CurrentState.FrameUpdate();

    }
    public void CheckConditionToChangeState()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            stateMachine.ChangeState(IdleState);
            Debug.Log("Enter idle state ");

        }
        else if (gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            stateMachine.ChangeState(RunState);
            Debug.Log("Run State ");
        }
        else if (Input.GetMouseButtonDown(0))
        {
            stateMachine.ChangeState(AttackState);
            Debug.Log("Attack State ");
        }

    }
}
