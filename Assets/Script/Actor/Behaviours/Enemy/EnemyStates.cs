using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; set; }
    public PlayerStateIdle IdleState { get; set; }
    public PlayerStateRun MoveState { get; set; }
    public PlayerAttackState AttackState { get; set; }
    public PlayerDeathState DeathState { get; set; }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
