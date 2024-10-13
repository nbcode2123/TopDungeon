using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActorStats
{
    float MaxHeath { get; set; }
    float currentHeath { get; set; }
    float MoveSpeed { get; set; }
    float AttackSpeed { get; set; }
    float DefaultAttackDamage { get; set; }

    string ActorName { set; get; }
    void Death();
}
