using Script.Actor.State_Machine;
using UnityEngine;

namespace Script.Actor.CharacterType.EnemyType.EyeBall
{
    public class EyeBallStates : MonoBehaviour
    {
        public StateMachine stateMachine;
        public EyeBallAttackState AttackState;
        public EyeBallIdleState IdleState;
        public GameObject player;
        void Awake()
        {
            stateMachine = new StateMachine();
            AttackState = new EyeBallAttackState(gameObject, stateMachine);
            IdleState = new EyeBallIdleState(gameObject, stateMachine);
            stateMachine.Initialize(IdleState);

        }

        // Start is called before the first frame update
        void Start()
        {
            player = GameManager.GameManager.Instance.Player;


        }
        // Update is called once per frame
        void Update()
        {

            stateMachine.CurrentState.FrameUpdate();
            CheckConditionToChangeState();

        }
        public void CheckConditionToChangeState()
        {
            Vector2 _playerTrans = player.transform.position;

            Vector2 _currentPosition = gameObject.transform.position;

            float _distance = Vector2.Distance(_currentPosition, _playerTrans);

            // Debug.Log(_distance);
            // Debug.Log(gameObject.GetComponent<EyeBallStats>().AttackRange);
            if (_distance <= gameObject.GetComponent<EyeBallStats>().AttackRange)
            {
                if (stateMachine.CurrentState != AttackState)
                {
                    stateMachine.ChangeState(AttackState);
                }
            }
            else if (_distance > gameObject.GetComponent<EyeBallStats>().AttackRange)
            {
                stateMachine.ChangeState(IdleState);
            }



        }
        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(gameObject.transform.position, gameObject.GetComponent<EyeBallStats>().AttackRange);
        }
    }
}
