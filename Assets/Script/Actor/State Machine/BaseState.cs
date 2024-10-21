using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public GameObject actor;
    public StateMachine stateMachine;
    public BaseState(GameObject actor, StateMachine stateMachine)
    {
        this.actor = actor;
        this.stateMachine = stateMachine;
    }
    // Start is called before the first frame update
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
}
