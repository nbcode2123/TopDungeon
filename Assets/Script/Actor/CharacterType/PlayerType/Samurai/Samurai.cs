using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour
{
    [Tooltip("Melee Attacker properties")]

    public Transform AttackTranform;
    public float AttackRange;
    public LayerMask AttackableLayer;
    public RaycastHit2D[] hits;
    public float AttackDmg;

    public IMeleeAttacker Attack;
    public void Start()
    {
        // Attack = GetComponent<IMeleeAttacker>();

        // Attack.AttackRange = AttackRange;
        // Attack.AttackableLayer = AttackableLayer;
        // Attack.AttackDmg = DefaultAttackDamage;



    }
    public void Update()
    {
        // Attack.AttackTranform = AttackTranform;


    }
    public void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(AttackTranform.transform.position, AttackRange);

    }


}
