using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerStates : MonoBehaviour
{
    public bool isDeath;
    public PlayerStateMachine StateMachine { get; set; }
    public PlayerStateIdle IdleState { get; set; }
    public PlayerStateRun RunState { get; set; }
    public PlayerAttackState AttackState { get; set; }
    public PlayerDeathState DeathState { get; set; }
    public float attackTimeCounter { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("PlayerDie", ChangeToDeathState);

    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<AllowControllActor>() == true)
        {
            CheckGameObjectToChangeState();

        }

        attackTimeCounter += Time.deltaTime;
    }
    public void CheckGameObjectToChangeState()
    {
        if (gameObject.GetComponent<AllowControllActor>().MoveDirection.x == 0 && gameObject.GetComponent<AllowControllActor>().MoveDirection.y == 0)
        {
            StateMachine.ChangeState(IdleState);
        }
        if ((gameObject.GetComponent<AllowControllActor>().MoveDirection.x != 0 || gameObject.GetComponent<AllowControllActor>().MoveDirection.y != 0) && gameObject.GetComponent<Animator>().GetBool("isBasicAttack") == false)
        {
            StateMachine.ChangeState(RunState);
        }
        if (Input.GetKeyDown(gameObject.GetComponent<AllowControllActor>().DefaultAttackBtn) && attackTimeCounter >= gameObject.GetComponent<IActorStats>().AttackSpeed)
        {
            attackTimeCounter = 0f;
            StateMachine.ChangeState(AttackState);
        }
    }
    public void ChangeToIdleState()
    {
        StateMachine.ChangeState(IdleState);
    }
    public void ChangeToDeathState()
    {
        StateMachine.ChangeState(DeathState);
    }





}
