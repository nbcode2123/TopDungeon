// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EyeBallStates : MonoBehaviour
// {
//     public StateMachine stateMachine;
//     public EyeBallAttackState AttackState;
//     public EyeBallIdleState IdleState;
//     void Awake()
//     {
//         stateMachine = new StateMachine();
//         AttackState = new EyeBallAttackState(gameObject, stateMachine);
//         IdleState = new EyeBallIdleState(gameObject, stateMachine);
//         stateMachine.Initialize(IdleState);

//     }

//     // Start is called before the first frame update
//     void Start()
//     {


//     }
//     // Update is called once per frame
//     void Update()
//     {

//         stateMachine.CurrentState.FrameUpdate();

//     }
//     void OnTriggerEnter2D(Collider2D collision)
//     {
//         Debug.Log(collision.name);
//     }
// }
