using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player Player, PlayerStateMachine PlayerStateMachine) : base(Player, PlayerStateMachine)
    {

    }

    // Start is called before the first frame update
    public override void EnterState()
    {
        base.EnterState();
        Player.animator.SetBool("isDeath", true);
    }

    public override void ExitState()
    {
        base.ExitState();
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
