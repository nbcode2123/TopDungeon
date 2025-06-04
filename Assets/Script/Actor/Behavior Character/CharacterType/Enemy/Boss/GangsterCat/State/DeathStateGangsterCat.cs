using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStateGangsterCat : State
{
    private GameObject Actor;
    private Animator Animator;
    public DeathStateGangsterCat(GameObject actor, Animator animator)
    {
        Actor = actor;
        Animator = animator;
    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("EnterDeathState");
        Actor.GetComponent<EnemyMarkRoomIndex>().OnDeath();

        Actor.SetActive(false);
    }
}
