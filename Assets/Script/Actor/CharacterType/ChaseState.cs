using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChaseState : BaseState
{
    private readonly GameObject target;
    private readonly Rigidbody2D rb;
    private readonly float MoveSpeed;
    public ChaseState(GameObject actor, StateMachine stateMachine, Animator animator, GameObject target) : base(actor, stateMachine, animator)
    {
        this.target = target;
        rb = actor.GetComponent<Rigidbody2D>();
        MoveSpeed = actor.GetComponent<CharactorStats>().MoveSpeed;

    }

    public override void EnterState()
    {
        animator.Play("Move");
    }

    public override void ExitState()
    {
        rb.velocity = Vector2.zero;
    }

    public override void FrameUpdate()
    {
        var _targetPos = target.transform.position;
        ChasingTarget(_targetPos);
    }
    public void ChasingTarget(Vector3 target)
    {
        var _moveDirection = new Vector2(target.x - actor.transform.position.x, target.y - actor.transform.position.y);
        _moveDirection.Normalize();
        rb.MovePosition(rb.position + _moveDirection * Time.fixedDeltaTime * MoveSpeed);

        // CheckForLeftOrRightFacing(rigidbodyCharactor.velocity);
    }
    // public void CheckForLeftOrRightFacing(Vector2 velocity)
    // {
    //     if (IsFaceingRight && velocity.x < 0f)
    //     {
    //         Vector3 rotator = new Vector3(transform.rotation.x, 180, transform.rotation.z);
    //         transform.rotation = Quaternion.Euler(rotator);
    //         IsFaceingRight = !IsFaceingRight;
    //     }
    //     else if (!IsFaceingRight && velocity.x > 0f)
    //     {
    //         Vector3 rotator = new Vector3(transform.rotation.x, 0, transform.rotation.z);
    //         transform.rotation = Quaternion.Euler(rotator);
    //         IsFaceingRight = !IsFaceingRight;
    //     }
    // }

}
