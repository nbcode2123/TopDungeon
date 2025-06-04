using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemyDeathState : EnemyDeathState
{
    private GameObject Weapon;
    public GoblinEnemyDeathState(GameObject actor, Animator animator, GameObject weapon) : base(actor, animator)
    {
        Actor = actor;
        Animator = animator;
        Weapon = weapon;
    }
    public override void EnterState()
    {
        base.EnterState();
        Actor.GetComponent<Collider2D>().enabled = false;
        Weapon.SetActive(false);

    }
}
