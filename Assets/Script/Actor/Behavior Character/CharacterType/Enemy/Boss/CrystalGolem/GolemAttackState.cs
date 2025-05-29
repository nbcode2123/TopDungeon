using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GolemAttackState : AttackState
{

    public GolemAttackState(GameObject actor, StateMachine stateMachine, Animator animator) : base(actor, stateMachine, animator)
    {
        this.animator = animator;
        this.actor = actor;
        this.stateMachine = stateMachine;

    }
    public override void EnterState()
    {

        actor.GetComponent<CrystalGolemAttackCombo>().StartCoroutineAttack();


    }

    public override void ExitState()
    {
        actor.GetComponent<CrystalGolemAttackCombo>().StopCoroutineAttack();
    }

    public override void FrameUpdate()
    {

    }









}
