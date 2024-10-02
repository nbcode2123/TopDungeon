using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{

    public EnemyIdleState(Enemy Enemy, EnemyStateMachine EnemyStateMachine) : base(Enemy, EnemyStateMachine)
    {
        enemy = Enemy;
        enemyStateMachine = EnemyStateMachine;

    }

    // Start is called before the first frame update
    public override void EnterState()
    {
        base.EnterState();

        enemy.animator.Play("Idle");
    }

    public override void ExitState()
    {

        base.ExitState();

    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.GetComponent<PlayerChaser>().FollowPlayer();



    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }




}
