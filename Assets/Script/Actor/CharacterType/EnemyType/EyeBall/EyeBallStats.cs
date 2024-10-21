using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EyeBallStats : MonoBehaviour, IActorStats
{
    public float AttackRange;
    [field: SerializeField]
    public float MoveSpeed { get; set; }
    [field: SerializeField]

    public float DefaultAttackDamage { get; set; }
    [field: SerializeField]

    public string ActorName { get; set; }
    [field: SerializeField]

    public float MaxHeath { get; set; }
    [field: SerializeField]

    public float currentHeath { get; set; }
    [field: SerializeField]

    public float AttackSpeed { get; set; }
    public bool isDeath { get; set; }
    public void Death()
    {
        gameObject.GetComponent<Animator>().SetBool("isDeath", true);

    }

    // Start is called before the first frame update
    void Start()
    {
        currentHeath = MaxHeath;

    }

    // Update is called once per frame
    void Update()
    {

        CheckDeath();

    }
    public void CheckDeath()
    {
        if (currentHeath <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("isDeath", true);
        }

    }


}
