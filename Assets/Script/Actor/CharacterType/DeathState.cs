using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    public DeathState(GameObject actor, StateMachine stateMachine, Animator animator) : base(actor, stateMachine, animator)
    {
    }

    public override void EnterState()
    {
        animator.Play("Death");
    }

    public override void ExitState()
    {
    }

    public override void FrameUpdate()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
