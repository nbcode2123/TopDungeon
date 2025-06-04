using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    private IState AttackState;
    private IState IdleState;
    private IState DeathState;
    private EnemyWeaponController WeaponController;
    [SerializeField] GameObject WeaponControllerObj;
    private Animator animator;
    private DamageCalculator DamageCalculator;
    private EnemyMarkRoomIndex EnemyMarkRoomIndex;
    [SerializeField] GameObject ColliderController;
    [SerializeField] private GameObject TargetPlayer;
    private EnemyColliderTrigger EnemyColliderTrigger;
    private IStateMachine stateMachine;
    [SerializeField] private bool isFacingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        DamageCalculator = gameObject.GetComponent<DamageCalculator>();
        EnemyMarkRoomIndex = gameObject.GetComponent<EnemyMarkRoomIndex>();
        WeaponController = WeaponControllerObj.GetComponent<EnemyWeaponController>();
        EnemyColliderTrigger = ColliderController.GetComponent<EnemyColliderTrigger>();
        AttackState = new EnemyAttackState(gameObject, animator);
        IdleState = new EnemyIdleState(gameObject, animator);
        DeathState = new GoblinEnemyDeathState(gameObject, animator, WeaponController.GetWeapon());

        stateMachine = new StateMachine2();
        stateMachine.Initialize(IdleState);

        DamageCalculator.OnDeath += ChangeToDeathState;
        DamageCalculator.OnDeath += EnemyMarkRoomIndex.OnDeath;
        EnemyColliderTrigger.RegisOnEnterCollider(WeaponController.SetTargetPlayer);
        EnemyColliderTrigger.RegisOnEnterCollider(SetTargetPlayer);
        EnemyColliderTrigger.RegisOnExitCollider(UnSetTargetPlayer);




    }

    public void AttackInvoke()
    {
        WeaponController.InvokeAttackWeapon();
    }
    public void SetTargetPlayer(GameObject target)
    {
        TargetPlayer = target;
        ChangeToAttackState();
    }
    public void UnSetTargetPlayer()
    {
        TargetPlayer = null;
        ChangeToIdleState();
    }
    public void ChangeToDeathState()
    {
        stateMachine.ChangeState(DeathState);

        DamageCalculator.OnDeath -= ChangeToDeathState;
        DamageCalculator.OnDeath -= EnemyMarkRoomIndex.OnDeath;
        EnemyColliderTrigger.UnRegisOnEnterCollider(WeaponController.SetTargetPlayer);
        EnemyColliderTrigger.UnRegisOnEnterCollider(SetTargetPlayer);
        EnemyColliderTrigger.UnRegisOnExitCollider(UnSetTargetPlayer);
    }
    public void ChangeToIdleState()
    {
        stateMachine.ChangeState(IdleState);
    }
    public void ChangeToAttackState()
    {
        stateMachine.ChangeState(AttackState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.CurrentState.FrameUpdate();
        FacingToPlayer();
    }
    public void FacingToPlayer()
    {
        if (TargetPlayer != null)
        {
            if (TargetPlayer.transform.position.x > gameObject.transform.position.x && !isFacingRight)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                isFacingRight = !isFacingRight;

            }
            else if (TargetPlayer.transform.position.x < gameObject.transform.position.x && isFacingRight)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                isFacingRight = !isFacingRight;
            }

        }
    }
    public void OnDestroy()
    {
        DamageCalculator.OnDeath -= ChangeToDeathState;
        DamageCalculator.OnDeath -= EnemyMarkRoomIndex.OnDeath;
        EnemyColliderTrigger.UnRegisOnEnterCollider(WeaponController.SetTargetPlayer);
        EnemyColliderTrigger.UnRegisOnEnterCollider(SetTargetPlayer);
        EnemyColliderTrigger.UnRegisOnExitCollider(UnSetTargetPlayer);

    }
}
