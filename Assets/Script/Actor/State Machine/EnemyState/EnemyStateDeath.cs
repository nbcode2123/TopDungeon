using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateDeath : EnemyState
{

    public EnemyStateDeath(Enemy Enemy, EnemyStateMachine EnemyStateMachine) : base(Enemy, EnemyStateMachine)
    {
        enemy = Enemy;
        enemyStateMachine = EnemyStateMachine;

    }

    // Start is called before the first frame update
    public override void EnterState()
    {
        base.EnterState();
        enemy.animator.SetBool("isDeath", true);
    }

    public override void ExitState()
    {

        base.ExitState();

    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        CheckEndAnimation();



    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }
    public void CheckEndAnimation()
    {

    }




}
