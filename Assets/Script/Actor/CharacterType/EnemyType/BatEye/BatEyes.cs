// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent(typeof(MeleeAttacker))]
// [RequireComponent(typeof(PlayerChaser))]


// public class BatEyes : Enemy
// {
//     [Tooltip("Melee Attacker properties ")]
//     public Transform AttackTranform;
//     public float AttackRange;
//     public LayerMask AttackableLayer;
//     public RaycastHit2D[] hits;
//     public float AttackDmg;
//     public IMeleeAttacker Attack;
//     [Header("Chase Player Properties ")]
//     public float AttackDistance;
//     public float OutRangeDistance;
//     public GameObject PlayerTrans;
//     private PlayerChaser PlayerChaser;


//     // Start is called before the first frame update
//     protected override void Start()
//     {
//         base.Start();
//         Attack = GetComponent<IMeleeAttacker>();
//         Attack.AttackRange = AttackRange;
//         Attack.AttackableLayer = AttackableLayer;
//         Attack.AttackDmg = DefaultAttackDamage;
//         PlayerChaser = gameObject.AddComponent<PlayerChaser>();
//         PlayerChaser.AttackDistance = AttackDistance;
//         PlayerChaser.OutRangeDistance = OutRangeDistance;
//         PlayerChaser.PlayerTrans = PlayerTrans;



//     }

//     // Update is called once per frame
//     protected override void Update()
//     {
//         base.Update();
//         Attack.AttackTranform = AttackTranform;
//         CheckConditionToChangeState();


//     }
//     public void OnDrawGizmosSelected()
//     {
//         Gizmos.DrawWireSphere(gameObject.transform.position, OutRangeDistance);
//         Gizmos.DrawWireSphere(gameObject.transform.position, AttackDistance);
//         Gizmos.DrawWireSphere(AttackTranform.transform.position, AttackRange);

//     }
//     public void CheckConditionToChangeState()
//     {
//         if (PlayerChaser.DistanceToPlayer > PlayerChaser.AttackDistance && animator.GetBool("isTakeDmg") == false && animator.GetBool("isDeath") == false)
//         {
//             enemyStateMachine.ChangeState(enemyIdleState);

//         }
//         if (PlayerChaser.DistanceToPlayer <= PlayerChaser.AttackDistance && animator.GetBool("isTakeDmg") == false && attackCounter >= gameObject.GetComponent<EnemyStats>().AttackSpeed)
//         {
//             Debug.Log("Attack");
//             attackCounter = 0f;
//             enemyStateMachine.ChangeState(enemyAttackState);

//         }
//         if (gameObject.GetComponent<EnemyStats>().currentHeath <= 0)
//         {
//             enemyStateMachine.ChangeState(enemyStateDeath);
//         }
//         if (gameObject.GetComponent<EnemyStats>().currentHeath > 0)
//         {
//             enemyStateMachine.ChangeState(enemyIdleState);
//         }

//     }
//     public void EndAnimationTakeDmg()
//     {


//     }
// }
