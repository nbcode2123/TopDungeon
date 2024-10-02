using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour, IMeleeAttacker
{
    public Transform AttackTranform { set; get; }
    public float AttackRange { set; get; }
    public LayerMask AttackableLayer { set; get; }
    public RaycastHit2D[] hits { set; get; }
    public float AttackDmg { set; get; }


    public void Attackdefault()
    {
        hits = Physics2D.CircleCastAll(AttackTranform.position, AttackRange, gameObject.transform.right, 0f, AttackableLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            string enemyName = hits[i].collider.gameObject.name;
            if (enemyName != null)
            {
                float targetHeal = hits[i].collider.gameObject.GetComponent<IActorStats>().currentHeath;
                if (targetHeal != 0)
                {
                    hits[i].collider.gameObject.GetComponent<TakeDamage>().DealDmgToActor(AttackDmg);


                }
            }
        }
    }
    // public void OnDrawGizmosSelected()
    // {
    //     Gizmos.DrawWireSphere(attackTranform.transform.position, attackRange / 2);


    // }
    // Start is called before the first frame update

}
