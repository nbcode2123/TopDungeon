using Script.Actor.State_Machine;
using UnityEngine;

namespace Script.Actor.CharacterType.EnemyType.EyeBall
{
    public class EyeBallIdleState : BaseState
    {
        public EyeBallIdleState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
        {
            this.actor = actor;
            this.stateMachine = stateMachine;


        }
        public override void EnterState()
        {

            base.EnterState();
            actor.transform.localScale = new Vector3(1, 1, 1);
            actor.transform.rotation = Quaternion.Euler(0, 0, 0);





        }
        public override void ExitState()
        {
            base.ExitState();


        }
        public override void FrameUpdate()
        {
            base.FrameUpdate();





        }



    }
}
