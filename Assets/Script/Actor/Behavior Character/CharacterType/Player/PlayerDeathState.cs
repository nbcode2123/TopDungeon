using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : DeathState
{
    public PlayerDeathState(GameObject actor, StateMachine stateMachine, Animator animator) : base(actor, stateMachine, animator)
    {
    }

    public override void EnterState()
    {
        actor.GetComponent<MovePlayer>().DeathFlag = true;
        WeaponController.Instance.CurrentWeapon.SetActive(false);
        base.EnterState();
    }
}
