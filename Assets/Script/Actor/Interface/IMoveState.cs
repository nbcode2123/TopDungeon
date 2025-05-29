using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveState
{
    BaseState MoveState { set; get; }
    void ChangeToMoveState();

}
