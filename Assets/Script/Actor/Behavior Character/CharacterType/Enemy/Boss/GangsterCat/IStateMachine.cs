using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    IState CurrentState { set; get; }
    void Initialize(IState state);
    void ChangeState(IState newState);
}
