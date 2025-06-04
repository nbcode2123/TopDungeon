using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyWeapon
{
    GameObject TargetPlayer { get; set; }
    void AttackInvoke();
    void SetTargetPlayer(GameObject target);


}
