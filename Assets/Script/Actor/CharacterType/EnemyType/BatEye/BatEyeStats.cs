using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEyeStats : MonoBehaviour, IActorStats
{
    [field: SerializeField]
    public float MaxHeath { get; set; }

    public float currentHeath { get; set; }
    [field: SerializeField]

    public float MoveSpeed { get; set; }
    [field: SerializeField]

    public float AttackSpeed { get; set; }
    [field: SerializeField]

    public float AttackDamage { get; set; }
    public string ActorName { get; set; }
    public bool isDeath { get; set; }


    public float AttackArea;
    public float ChaseRange;
    public float AttackRange;
    public GameObject AttackTransform;




    public void Death()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, ChaseRange);
        Gizmos.DrawWireSphere(gameObject.transform.position, AttackRange);
        Gizmos.DrawWireSphere(AttackTransform.transform.position, AttackArea);


    }
}
