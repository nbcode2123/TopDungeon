using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorStats : MonoBehaviour
{
    [field: SerializeField]
    public float MaxHealth { get; set; }
    [field: SerializeField]
    public float currentHealth { get; set; }
    [field: SerializeField]
    public float MoveSpeed { get; set; }

    [field: SerializeField]
    public float AttackDamage { get; set; }
    [field: SerializeField]
    public string ActorName { get; set; }



    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

}
