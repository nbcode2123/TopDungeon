using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallStates : MonoBehaviour
{
    public StateMachine stateMachine;
    public EyeBallAttackState AttackState;
    public EyeBallIdleState IdleState;
    public EyeBallDeathState DeathState;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        AttackState = new EyeBallAttackState(gameObject, stateMachine);
        IdleState = new EyeBallIdleState(gameObject, stateMachine);
        DeathState = new EyeBallDeathState(gameObject, stateMachine);

        stateMachine.Initialize(IdleState);







    }
    // Update is called once per frame
    void Update()
    {
        stateMachine.CurrentState.FrameUpdate();

    }
    public void CheckConditionToChangeState()
    {

    }
}
