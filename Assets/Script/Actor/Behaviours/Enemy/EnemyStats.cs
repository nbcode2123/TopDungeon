using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IActorStats
{
    public float MaxHeath { get; set; }
    public float currentHeath { get; set; }
    public float MoveSpeed { get; set; }
    public float AttackSpeed { get; set; }
    public float DefaultAttackDamage { get; set; }
    public string CharacterRangeAttack { get; set; }
    public Sprite RangeAttackIcon { get; set; }
    public string BasicAttackName { get; set; }
    public Sprite BasicAttackIcon { get; set; }
    public string ActorName { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
