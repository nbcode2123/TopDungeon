using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public float WeaponDamage { get; set; }
    public float WeaponAttackSpeed { get; set; }
    public void Attack();

}