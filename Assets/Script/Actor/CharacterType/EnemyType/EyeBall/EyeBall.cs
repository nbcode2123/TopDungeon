using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EyeBallLooking))]
[RequireComponent(typeof(EyeBallShooter))]

public class EyeBall : Enemy
{
    public float RangeAttack;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();




    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, RangeAttack);

    }


}
