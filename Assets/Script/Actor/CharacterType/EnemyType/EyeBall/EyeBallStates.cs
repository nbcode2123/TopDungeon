using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallStates : MonoBehaviour
{
    public StateMachine stateMachine;
    public EyeBallAttackState AttackState;
    public EyeBallIdleState IdleState;
    public EyeBallDeathState DeathState;
    public GameObject player;
    public Vector3 palyerTrans;
    void Awake()
    {
        stateMachine = new StateMachine();
        AttackState = new EyeBallAttackState(gameObject, stateMachine);
        IdleState = new EyeBallIdleState(gameObject, stateMachine);
        DeathState = new EyeBallDeathState(gameObject, stateMachine);
    }

    // Start is called before the first frame update
    void Start()
    {


        stateMachine.Initialize(IdleState);
        player = GameManager.Instance.Player;







    }
    // Update is called once per frame
    void Update()
    {
        stateMachine.CurrentState.FrameUpdate();
        CheckConditionToChangeState();

    }
    public void CheckConditionToChangeState()
    {


    }
}
