using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public GameObject actor;
    public StateMachine stateMachine;
    public Animator animator;
    public bool isComplete;
    public BaseState(GameObject actor, StateMachine stateMachine, Animator animator)
    {
        this.actor = actor;
        this.stateMachine = stateMachine;
        this.animator = animator;

    }
    // Start is called before the first frame update
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void FrameUpdate();
}
