using Script.Actor.State_Machine;
using Script.GameManager.Logic;
using UnityEngine;

namespace Script.Actor.CharacterType.EnemyType.BatEye
{
    public class BatEyeChaseState : BaseState
    {
        public BatEyeChaseState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
        {

        }
        // Start is called before the first frame update


        public override void EnterState()
        {
            base.EnterState();

        }
        public override void FrameUpdate()
        {
            base.FrameUpdate();
            actor.GetComponent<PlayerChaser>().FollowPlayer();

        }
        public override void ExitState()
        {
            base.ExitState();
        }
    }
}
