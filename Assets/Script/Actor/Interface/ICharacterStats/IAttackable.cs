using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    int AttackDamage { set; get; }
    float AttackSpeed { set; get; }
    int GetAttackDamage();
    void IncreaseAttackDamage(int value);
    void DecreaseAttackDamage(int value);
    float GetAttackSpeed();
    void IncreaseAttackSpeed(int value);
    void DecreaseAttackSpeed(int value);


}
