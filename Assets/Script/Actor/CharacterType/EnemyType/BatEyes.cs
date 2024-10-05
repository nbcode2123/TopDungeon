using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeleeAttacker))]

public class BatEyes : Enemy
{
    [Tooltip("Melee Attacker properties ")]
    public Transform AttackTranform;
    public float AttackRange;
    public LayerMask AttackableLayer;
    public RaycastHit2D[] hits;
    public float AttackDmg;

    public IMeleeAttacker Attack;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Attack = GetComponent<IMeleeAttacker>();

        Attack.AttackRange = AttackRange;
        Attack.AttackableLayer = AttackableLayer;
        Attack.AttackDmg = DefaultAttackDamage;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Attack.AttackTranform = AttackTranform;


    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, OutRangeDistance);
        Gizmos.DrawWireSphere(gameObject.transform.position, AttackDistance);
        Gizmos.DrawWireSphere(AttackTranform.transform.position, AttackRange);

    }
    public void EndAnimationTakeDmg()
    {


    }
}
