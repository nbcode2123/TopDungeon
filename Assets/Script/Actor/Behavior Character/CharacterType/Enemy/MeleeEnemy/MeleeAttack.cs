using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAttackerEnemy
{
    public float damage;
    public float Damage
    {
        get => damage;
        set => damage = value;

    }
    public float attackSpeed;

    public event Action OnAttack;
    public event Action OnExitAttack;

    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    public void Attack()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAttackInvoke()
    {
        OnAttack?.Invoke();
    }

    public void OnExitAttackInvoke()
    {
        OnExitAttack?.Invoke();
    }
}
