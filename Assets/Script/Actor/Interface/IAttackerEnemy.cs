using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackerEnemy
{
    public float Damage { set; get; }
    public float AttackSpeed { set; get; }
    public void Attack();
    public event Action OnAttack;
    public event Action OnExitAttack;
    public void OnAttackInvoke();
    public void OnExitAttackInvoke();

}
