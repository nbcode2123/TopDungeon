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
    string CharacterRangeAttack { set; get; }
    Sprite RangeAttackIcon { set; get; }
    string BasicAttackName { set; get; }
    Sprite BasicAttackIcon { set; get; }
    string ActorName { set; get; }
}
