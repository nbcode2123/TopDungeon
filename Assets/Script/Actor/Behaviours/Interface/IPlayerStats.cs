using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStats : IActorStats
{
    GameObject DefaultWeapon { get; set; }
    string Skill { get; set; }
    bool isDeath { get; set; }

}
