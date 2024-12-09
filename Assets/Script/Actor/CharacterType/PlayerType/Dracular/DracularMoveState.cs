using Script.Actor.State_Machine;
using UnityEngine;

namespace Script.Actor.CharacterType.PlayerType.Dracular
{
    public class DracularMoveState : BaseState
    {
        public DracularMoveState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
        {

        }
        public override void EnterState()
        {
            base.EnterState();
            actor.GetComponent<Animator>().SetBool("isMove", true);
        }
        public override void ExitState()
        {
            base.ExitState();
            actor.GetComponent<Animator>().SetBool("isMove", false);

        }
        public override void FrameUpdate()
        {
            base.FrameUpdate();
        }
    }
}
