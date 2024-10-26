using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActorStats
{
    string ActorName { get; set; }
    float MaxHeath { get; set; }
    float currentHeath { get; set; }
    float MoveSpeed { get; set; }
    float AttackDamage { get; set; }

}
