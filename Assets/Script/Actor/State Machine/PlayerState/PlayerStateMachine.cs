using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState CurrentPlayerBaseState { get; set; }
    public void Initialize(PlayerState startingState)
    {
        CurrentPlayerBaseState = startingState;
        CurrentPlayerBaseState.EnterState();

    }
    public void ChangeState(PlayerState newState)
    {
        CurrentPlayerBaseState.ExitState();
        CurrentPlayerBaseState = newState;
        CurrentPlayerBaseState.EnterState();
    }
}
