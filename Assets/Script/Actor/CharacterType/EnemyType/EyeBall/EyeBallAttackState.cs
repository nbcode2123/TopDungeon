using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallAttackState : BaseState
{
    public float attackCounter;
    public GameObject player;
    public float AttackCounter = 0;

    public EyeBallAttackState(GameObject actor, StateMachine stateMachine) : base(actor, stateMachine)
    {
        this.actor = actor;
        this.stateMachine = stateMachine;
    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("enter attack state ");
        Debug.Log(actor.GetComponent<IActorStats>().AttackSpeed);
    }
    public override void ExitState()
    {
        base.ExitState();
        actor.GetComponent<Animator>().SetBool("isAttack", false);
        actor.transform.rotation = Quaternion.identity;
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        actor.GetComponent<EyeBallLooking>().LookToPlayer();
        ControllAnimationAttack();

        // Debug.Log(attackCounter);

    }
    private void ControllAnimationAttack()
    {
        attackCounter += Time.deltaTime;
        if (attackCounter > actor.GetComponent<IActorStats>().AttackSpeed)
        {
            actor.GetComponent<Animator>().SetBool("isAttack", true);
            attackCounter = 0;

        }
        else if (attackCounter < actor.GetComponent<IActorStats>().AttackSpeed)
        {
            actor.GetComponent<Animator>().SetBool("isAttack", false);

        }
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();

    }



}
