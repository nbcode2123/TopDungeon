// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class BatEyeAttackState : BaseState
// {
//     public float attackcounter = 0;
//     public BatEyeAttackState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
//     {



//     }
//     public override void EnterState()
//     {
//     }
//     public override void FrameUpdate()
//     {
//         attackcounter += Time.deltaTime;
//         if (attackcounter > actor.GetComponent<BatEyeStats>().AttackSpeed)
//         {
//             actor.GetComponent<Animator>().SetBool("isAttack", true);
//             attackcounter = 0;
//         }

//     }
//     public override void ExitState()
//     {

//         actor.GetComponent<Animator>().SetBool("isAttack", false);

//     }

// }
