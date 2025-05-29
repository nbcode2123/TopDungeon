using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    int WeaponDamage { get; set; }
    float WeaponAttackSpeed { get; set; }
    int WeaponEnergy { get; set; }
    void Attack();
    bool ActiveWeapon { get; set; }
    void DisableWeapon();
    void EnableWeapon();



}
