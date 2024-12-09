using UnityEngine;

namespace Script.Actor.Behaviours.Interface
{
    public interface IPlayerStats : IActorStats
    {
        GameObject DefaultWeapon { get; set; }
        string Skill { get; set; }
        bool isDeath { get; set; }

    }
}
