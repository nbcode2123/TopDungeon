using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRun : PlayerState
{
    public Animator animator { get; set; }

    public PlayerStateRun(Player Player, PlayerStateMachine playerStateMachine) : base(Player, playerStateMachine)
    {
        this.Player = Player;
    }


    public override void EnterState()
    {
        base.EnterState();
        animator = Player.animator;
        animator.SetBool("isRunning", true);
    }
    public override void ExitState()
    {
        base.ExitState();
        animator = Player.animator;
        animator.SetBool("isRunning", false);

    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();

    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
    }

    public void PerformRunStateAnimation()
    {
        animator = Player.animator;
        animator.SetBool("isRunning", true);

    }

    public void PlayAnimation(string animationName, Animator animator)
    {
        animator.Play(animationName);
    }
}
