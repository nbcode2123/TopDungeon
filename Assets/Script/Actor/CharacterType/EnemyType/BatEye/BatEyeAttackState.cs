using Script.Actor.State_Machine;
using UnityEngine;

namespace Script.Actor.CharacterType.EnemyType.BatEye
{
    public class BatEyeAttackState : BaseState
    {
        public float attackcounter = 0;
        public BatEyeAttackState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
        {



        }
        public override void EnterState()
        {
            base.EnterState();
        }
        public override void FrameUpdate()
        {
            base.FrameUpdate();
            attackcounter += Time.deltaTime;
            if (attackcounter > actor.GetComponent<BatEyeStats>().AttackSpeed)
            {
                actor.GetComponent<Animator>().SetBool("isAttack", true);
                attackcounter = 0;
            }

        }
        public override void ExitState()
        {
            base.ExitState();
            actor.GetComponent<Animator>().SetBool("isAttack", false);

        }

    }
}
