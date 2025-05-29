using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIdleState
{
    BaseState IdleState { get; set; }
    void ChangeToIdleState();

}
