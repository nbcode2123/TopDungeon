using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEyeStates : MonoBehaviour
{
    public BatEyeAttackState AttackState;
    public BatEyeIdleState IdleState;
    public StateMachine stateMachine;
    public BatEyeChaseState ChaseState;
    private Vector3 PlayerPos;
    private float AttackRange;
    private float ChaseRange;
    void Awake()
    {
        stateMachine = new StateMachine();
        IdleState = new BatEyeIdleState(gameObject, stateMachine);
        AttackState = new BatEyeAttackState(gameObject, stateMachine);
        ChaseState = new BatEyeChaseState(gameObject, stateMachine);
        stateMachine.Initialize(IdleState);

    }

    // Start is called before the first frame update
    void Start()
    {
        AttackRange = gameObject.GetComponent<BatEyeStats>().AttackRange;
        ChaseRange = gameObject.GetComponent<BatEyeStats>().ChaseRange;




    }

    // Update is called once per frame
    void Update()
    {
        CheckConditionToChangeState();
        stateMachine.CurrentState.FrameUpdate();

    }
    public void CheckConditionToChangeState()
    {
        PlayerPos = GameManager.Instance.Player.transform.position;
        var _distance = Vector2.Distance(PlayerPos, gameObject.transform.position);
        if (_distance > ChaseRange)
        {
            stateMachine.ChangeState(IdleState);

        }
        else if (_distance < ChaseRange && _distance > AttackRange)
        {
            stateMachine.ChangeState(ChaseState);
        }
        else if (_distance <= AttackRange)
        {
            stateMachine.ChangeState(AttackState);


        }






    }
}
