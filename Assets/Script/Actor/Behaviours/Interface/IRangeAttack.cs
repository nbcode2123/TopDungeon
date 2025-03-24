using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackState
{
    BaseState AttackState { set; get; }
    void ChangeToAttackState();

}
