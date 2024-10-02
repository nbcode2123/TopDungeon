using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player Player, PlayerStateMachine playerStateMachine) : base(Player, playerStateMachine)
    {

    }
    public override void EnterState()
    {
        base.EnterState();
        Player.animator.SetBool("isBasicAttack", true);
    }
    public override void ExitState()
    {
        base.ExitState();
        Player.animator.SetBool("isBasicAttack", false);


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
