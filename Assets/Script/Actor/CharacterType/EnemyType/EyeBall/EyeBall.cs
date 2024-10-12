using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EyeBallLooking))]
[RequireComponent(typeof(EyeBallShooter))]
[RequireComponent(typeof(EyeBallStates))]



public class EyeBall : Enemy
{
    public float RangeAttack;
    public float BulletSpeed;
    public GameObject Bullet;

    public EyeBallLooking eyeBallLooking { get; set; }
    public EyeBallShooter eyeBallShooter { get; set; }
    public EyeBallStates eyeBallStates { get; set; }
    protected override void Awake()
    {


    }



    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        eyeBallShooter.Damage = DefaultAttackDamage;
        eyeBallShooter.Speed = BulletSpeed;
        eyeBallShooter.Bullet = Bullet;
        eyeBallShooter.RangeAttack = RangeAttack;



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
