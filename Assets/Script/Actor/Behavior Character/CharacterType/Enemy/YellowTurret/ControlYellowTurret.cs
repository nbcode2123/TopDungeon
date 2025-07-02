using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlYellowTurret : MonoBehaviour
{
    public GameObject HeadTurret;
    public GameObject BodyTurret;
    public GameObject RangAttack;
    public GameObject ShootSystem;
    private DamageCalculator damageCalculator;
    private EnemyStats enemyStats;
    private HeadYellowTurret headYellowTurret;
    private YellowTurretRangeAttackTrigger yellowTurretRangeAttackTrigger;
    private YellowTurretShootSystem turretShootSystem;
    public GameObject Actor;

    // Start is called before the first frame update
    private void OnEnable()
    {
        BodyTurret.SetActive(true);



    }
    private void Start()
    {

        headYellowTurret = HeadTurret.GetComponent<HeadYellowTurret>();
        yellowTurretRangeAttackTrigger = RangAttack.GetComponent<YellowTurretRangeAttackTrigger>();
        turretShootSystem = ShootSystem.GetComponent<YellowTurretShootSystem>();
        turretShootSystem.SetBullet(gameObject.GetComponent<RangeAttack>().Bullet);//! can sua lai rangeweapn
        damageCalculator = gameObject.GetComponent<DamageCalculator>();
        enemyStats = gameObject.GetComponent<EnemyStats>();

        damageCalculator.OnDeath += LockWhenDeath;
        damageCalculator.OnDeath += gameObject.GetComponent<EnemyMarkRoomIndex>().OnDeath;



        yellowTurretRangeAttackTrigger.RegisterOnEnterCollider(headYellowTurret.SetTarget);
        yellowTurretRangeAttackTrigger.RegisterOnExitCollider(headYellowTurret.UnSetTarget);
        yellowTurretRangeAttackTrigger.RegisterOnEnterCollider(turretShootSystem.StartCoroutineAttack);
        yellowTurretRangeAttackTrigger.RegisterOnExitCollider(turretShootSystem.StopCoroutineAttack);



    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        yellowTurretRangeAttackTrigger.UnRegisterOnEnterCollider(headYellowTurret.SetTarget);
        yellowTurretRangeAttackTrigger.UnRegisterOnExitCollider(headYellowTurret.UnSetTarget);
        yellowTurretRangeAttackTrigger.UnRegisterOnEnterCollider(turretShootSystem.StartCoroutineAttack);
        yellowTurretRangeAttackTrigger.RegisterOnExitCollider(turretShootSystem.StopCoroutineAttack);



    }
    private void OnDisable()
    {
        yellowTurretRangeAttackTrigger.UnRegisterOnEnterCollider(headYellowTurret.SetTarget);
        yellowTurretRangeAttackTrigger.UnRegisterOnExitCollider(headYellowTurret.UnSetTarget);
        yellowTurretRangeAttackTrigger.UnRegisterOnEnterCollider(turretShootSystem.StartCoroutineAttack);
        yellowTurretRangeAttackTrigger.UnRegisterOnExitCollider(turretShootSystem.StopCoroutineAttack);


    }

    private void LockWhenDeath()
    {
        headYellowTurret.UnSetTarget();
        yellowTurretRangeAttackTrigger.UnRegisterOnEnterCollider(headYellowTurret.SetTarget);
        yellowTurretRangeAttackTrigger.UnRegisterOnExitCollider(headYellowTurret.UnSetTarget);
        yellowTurretRangeAttackTrigger.UnRegisterOnEnterCollider(turretShootSystem.StartCoroutineAttack);
        yellowTurretRangeAttackTrigger.RegisterOnExitCollider(turretShootSystem.StopCoroutineAttack);
        turretShootSystem.StopCoroutineAttack();
        headYellowTurret.Death();
        BodyTurret.SetActive(false);
        Actor.GetComponent<Collider2D>().enabled = false;
    }
}
