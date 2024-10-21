using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiStats : MonoBehaviour, IActorStats
{
    [field: SerializeField]
    public float MaxHeath { get; set; }
    public float currentHeath { get; set; }
    [field: SerializeField]
    public float MoveSpeed { get; set; }
    [field: SerializeField]
    public float AttackSpeed { get; set; }
    [field: SerializeField]
    public float DefaultAttackDamage { get; set; }
    public bool isDeath { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
