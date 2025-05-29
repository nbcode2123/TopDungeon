using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour, IAttackerEnemy
{
    [Header("IAttack property")]
    public float damage;
    public float Damage
    {
        get => damage;
        set => damage = value;
    }
    public float attackSpeed;

    protected Action OnAttack;
    protected Action OnExitAttack;
    public GameObject Bullet;

    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    event Action IAttackerEnemy.OnAttack
    {
        add
        {
        }

        remove
        {
        }
    }

    event Action IAttackerEnemy.OnExitAttack
    {
        add
        {
        }

        remove
        {
        }
    }

    public virtual void Attack()
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

    void IAttackerEnemy.Attack()
    {
        throw new NotImplementedException();
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
