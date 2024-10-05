using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControll : MonoBehaviour
{
    public GameObject Actor;
    public float AttackSpeed;
    public float attackCounter = 0;
    void Awake()
    {
        Actor = gameObject;
        AttackSpeed = gameObject.GetComponent<IActorStats>().AttackSpeed;

    }

    // Start is called before the first frame update
    protected void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        attackCounter += Time.deltaTime;

    }
    public void ChangeToAttackState()
    {
        if (attackCounter > AttackSpeed)
        {

        }

    }
}
