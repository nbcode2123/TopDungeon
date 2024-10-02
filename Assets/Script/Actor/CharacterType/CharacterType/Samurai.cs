using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeleeAttacker))]
public class Samurai : Player
{
    [Tooltip("Melee Attacker properties")]

    public Transform AttackTranform;
    public float AttackRange;
    public LayerMask AttackableLayer;
    public RaycastHit2D[] hits;
    public float AttackDmg;

    public IMeleeAttacker Attack;
    protected override void Start()
    {
        base.Start();
        Attack = GetComponent<IMeleeAttacker>();

        Attack.AttackRange = AttackRange;
        Attack.AttackableLayer = AttackableLayer;
        Attack.AttackDmg = DefaultAttackDamage;



    }
    protected override void Update()
    {
        base.Update();
        Attack.AttackTranform = AttackTranform;


    }
    public void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(AttackTranform.transform.position, AttackRange);

    }


}
