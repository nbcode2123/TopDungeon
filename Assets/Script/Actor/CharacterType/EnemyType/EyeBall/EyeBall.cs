using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EyeBallLooking))]
[RequireComponent(typeof(EyeBallShooter))]
[RequireComponent(typeof(EyeBallStates))]
[RequireComponent(typeof(EyeBallStats))]



public class EyeBall : MonoBehaviour
{
    public float RangeAttack;
    public float BulletSpeed;
    public GameObject Bullet;
    public Animator animator;
    public EyeBallLooking eyeBallLooking { get; set; }
    public EyeBallShooter eyeBallShooter { get; set; }
    public EyeBallStates eyeBallStates { get; set; }
    protected void Awake()
    {
        eyeBallShooter = gameObject.GetComponent<EyeBallShooter>();
        eyeBallLooking = gameObject.GetComponent<EyeBallLooking>();
        eyeBallStates = gameObject.GetComponent<EyeBallStates>();
        eyeBallShooter.Speed = BulletSpeed;
        eyeBallShooter.Bullet = Bullet;
        eyeBallShooter.RangeAttack = RangeAttack;


    }



    // Start is called before the first frame update
    protected void Start()
    {





    }

    // Update is called once per frame
    protected void Update()
    {





    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, RangeAttack);

    }




}
