using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine2 : IStateMachine
{
    public IState CurrentState { get; set; }

    public void ChangeState(IState newState)
    {

        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();

    }

    public void Initialize(IState state)
    {
        state.EnterState();
        CurrentState = state;

    }


}
