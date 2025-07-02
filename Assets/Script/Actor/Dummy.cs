using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : DamageCalculator
{

    public override void TakeDamage(int damage)
    {
        gameObject.GetComponent<Animator>().Play("Attack");
        ObserverManager.Notify("ShowDamage", gameObject.transform.position);
        ObserverManager.Notify("ShowDamage", damage);

    }
    public void EndAnimation()
    {
        gameObject.GetComponent<Animator>().Play("Idle");

    }
}
