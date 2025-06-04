using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStateGangsterCat : State
{
    private GameObject Actor;
    private Animator Animator;
    public ShootStateGangsterCat(GameObject actor, Animator animator)
    {
        Actor = actor;
        Animator = animator;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        Actor.GetComponent<ShootExecution>().InvokeRandomShootPattern();
    }
    public override void EnterState()
    {
        base.EnterState();
        Animator.Play("Shoot");
        Actor.GetComponent<ShootExecution>().ChooseRandomPattern();


    }
}
