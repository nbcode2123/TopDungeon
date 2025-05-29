using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallGolemStateController : MonoBehaviour
{
    // public GameObject EyeArea;
    public GameObject EyeArea;
    private BaseState AttackState;
    private BaseState DeathState;
    private BaseState IdleState;
    public StateMachine stateMachine;
    private Animator animator;
    public GameObject TargetPlayer;
    private CrystalGolemAttackMoveset AttackMoveSet;


    // Start is called before the first frame update
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        stateMachine = new StateMachine();
        IdleState = new IdleState(gameObject, stateMachine, animator);
        DeathState = new DeathState(gameObject, stateMachine, animator);
        AttackState = new GolemAttackState(gameObject, stateMachine, animator);
        stateMachine.Initialize(IdleState);
        AttackMoveSet = gameObject.GetComponent<CrystalGolemAttackMoveset>();
        EyeArea.GetComponent<EyeArea>().DetectObject += DetectPlayer;
        EyeArea.GetComponent<EyeArea>().OnEnterTrigger += ChangeToAttackState;
        gameObject.GetComponent<DamageCalculator>().OnDeath += LockDeathState;
        gameObject.GetComponent<DamageCalculator>().OnDeath += ChangeToDeathState;

    }
    void Start()
    {




        // ChaseState = new GolemChaseState(gameObject, stateMachine, animator);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeToAttackState()
    {
        stateMachine.ChangeState(AttackState);

    }
    public void ChangeToDeathState()
    {
        stateMachine.ChangeState(DeathState);
    }



    public void DetectPlayer(GameObject player)
    {
        TargetPlayer = player;
        AttackMoveSet.TargetPlayer = player;
        Debug.Log(TargetPlayer.name);

    }
    public void LockDeathState()
    {
        EyeArea.GetComponent<EyeArea>().OnEnterTrigger -= ChangeToAttackState;
        EyeArea.GetComponent<EyeArea>().DetectObject -= DetectPlayer;

    }


}
