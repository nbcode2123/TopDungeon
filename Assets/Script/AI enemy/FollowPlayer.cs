using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

public class FollowPlayer : MonoBehaviour
{

    [Header("OutRangeDistance - StopChaseDistance = Attack Range  ")]
    public float ChaseSpeed = 5.0f;
    public float StopChaseDistance = 2.0f;
    public float OutRangeDistance = 5.0f;
    private Transform PlayerTrans;
    public Vector2 moveDirection;
    public float movementSpeed;
    public Animator animator;
    public float DistanceToPlayer;
    void Start()
    {
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        FollowDirection();

    }
    public Vector2 FollowDirection()
    {
        DistanceToPlayer = Vector2.Distance(transform.position, PlayerTrans.position);
        moveDirection = new Vector2(PlayerTrans.position.x - transform.position.x, PlayerTrans.position.y - transform.position.y);
        movementSpeed = Mathf.Clamp(moveDirection.magnitude, 0.0f, 1.0f);
        moveDirection.Normalize();
        if (Vector2.Distance(transform.position, PlayerTrans.position) > StopChaseDistance && Vector2.Distance(transform.position, PlayerTrans.position) < OutRangeDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTrans.position, ChaseSpeed * Time.deltaTime);
            if (moveDirection.x > 0)
            {
                animator.SetFloat("Horizontal", 1);
            }
            else if (moveDirection.x < 0)
            {
                animator.SetFloat("Horizontal", -1);

            }

        }
        else if ((Vector2.Distance(transform.position, PlayerTrans.position) > OutRangeDistance || Vector2.Distance(transform.position, PlayerTrans.position) <= StopChaseDistance) && moveDirection.x > 0)
        {
            moveDirection = Vector2.zero;
            animator.SetFloat("Horizontal", 0.1f);
        }
        else if ((Vector2.Distance(transform.position, PlayerTrans.position) > OutRangeDistance || Vector2.Distance(transform.position, PlayerTrans.position) <= StopChaseDistance) && moveDirection.x < 0)
        {
            moveDirection = Vector2.zero;
            animator.SetFloat("Horizontal", -0.1f);
        }

        return moveDirection;

    }
}
