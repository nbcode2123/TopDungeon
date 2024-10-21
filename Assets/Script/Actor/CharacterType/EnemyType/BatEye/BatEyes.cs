using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEyes : MonoBehaviour
{


    // Start is called before the first frame update
    public void Start()
    {




    }

    // Update is called once per frame
    public void Update()
    {



    }
    public void OnDrawGizmosSelected()
    {
        // Gizmos.DrawWireSphere(gameObject.transform.position, OutRangeDistance);
        // Gizmos.DrawWireSphere(gameObject.transform.position, AttackDistance);
        // Gizmos.DrawWireSphere(AttackTranform.transform.position, AttackRange);


    }
    public void setEndAttackAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("isAttack", false);
    }
}
