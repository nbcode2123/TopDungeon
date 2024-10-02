using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState
{


    public PlayerStateIdle(Player Player, PlayerStateMachine playerStateMachine) : base(Player, playerStateMachine)
    {
        this.Player = Player;
        this.playerStateMachine = playerStateMachine;
    }
    public override void EnterState()
    {
        base.EnterState();
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        PerformIdleState();
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }
    public void PerformIdleState()
    {
        Player.animator.SetBool("isRunning", false);

    }


}
