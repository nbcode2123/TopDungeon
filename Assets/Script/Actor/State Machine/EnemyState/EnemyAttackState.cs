using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    // Start is called before the first frame update
    public EnemyAttackState(Enemy Enemy, EnemyStateMachine EnemyStateMachine) : base(Enemy, EnemyStateMachine)
    {
        enemy = Enemy;
        enemyStateMachine = EnemyStateMachine;
    }
    public override void EnterState()
    {
        base.EnterState();
        enemy.animator.SetBool("isAttack", true);

    }
    public override void ExitState()
    {
        base.ExitState();
        enemy.animator.SetBool("isAttack", false);
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();

    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }



}
