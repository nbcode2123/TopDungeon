using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    // Start is called before the first frame update
    public Enemy enemy;
    public EnemyStateMachine enemyStateMachine;
    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicalUpdate() { }


}
