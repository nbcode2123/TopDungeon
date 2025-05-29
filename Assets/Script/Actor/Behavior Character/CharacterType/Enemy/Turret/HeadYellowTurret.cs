using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadYellowTurret : MonoBehaviour
{
    private GameObject Target;
    private bool isLockTarget = false;
    private bool IsFaceingRight = true;
    public float speedRotate = 10;
    private Animator animator;
    public void LockToTarget()
    {
        if (Target != null)
        {


            Vector3 vectorToTarget = Target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedRotate);
        }



    }

    public void SetTarget(GameObject target)
    {

        Target = target;
        isLockTarget = true;


    }
    public void UnSetTarget()
    {

        isLockTarget = false;
        Target = null;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }


    public void CheckForLeftOrRightFacing()
    {
        if (IsFaceingRight && Target.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, -1, 1);
            IsFaceingRight = !IsFaceingRight;
        }
        else if (!IsFaceingRight && Target.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            IsFaceingRight = !IsFaceingRight;
        }
    }
    public void Update()
    {
        if (isLockTarget == true)
        {
            CheckForLeftOrRightFacing();
            LockToTarget();
        }

    }
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void Death()
    {
        animator.Play("Death");

    }



}
