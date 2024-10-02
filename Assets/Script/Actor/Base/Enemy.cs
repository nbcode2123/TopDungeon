using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerChaser))]
[RequireComponent(typeof(MeleeAttacker))]
[RequireComponent(typeof(TakeDamage))]
[RequireComponent(typeof(EnemyStats))]
public abstract class Enemy : MonoBehaviour
{

    [Header("Actor State ")]
    public float MaxHeath;
    public float currentHeath;
    public float MoveSpeed;
    public float AttackSpeed;
    public float DefaultAttackDamage;

    [Header("Take Damge")]
    public GameObject textDmg;
    public Vector3 GameObjectTransformPosition;
    [Header("Chase Player Properties ")]
    public float AttackDistance;
    public float OutRangeDistance;
    public GameObject PlayerTrans;




    #region Enemy base properties 
    public EnemyState enemyState { get; set; }
    public EnemyStateMachine enemyStateMachine { get; set; }
    public EnemyAttackState enemyAttackState { get; set; }
    public EnemyIdleState enemyIdleState { get; set; }
    public EnemyStateDeath enemyStateDeath { get; set; }
    public float attackCounter;
    public Rigidbody2D RB { get; set; }
    public Animator animator { get; set; }
    private PlayerChaser PlayerChaser;
    private TakeDamage TakeDamage;
    private IActorStats ActorStats;


    #endregion






    #region Enemy Base Methods 
    public void Awake()
    {
        enemyStateMachine = new EnemyStateMachine();
        enemyIdleState = new EnemyIdleState(this, enemyStateMachine);
        enemyAttackState = new EnemyAttackState(this, enemyStateMachine);
        enemyStateDeath = new EnemyStateDeath(this, enemyStateMachine);
        PlayerChaser = gameObject.GetComponent<PlayerChaser>();
        ActorStats = gameObject.GetComponent<IActorStats>();
        TakeDamage = gameObject.GetComponent<TakeDamage>();

        ActorStats.MaxHeath = MaxHeath;
        ActorStats.currentHeath = MaxHeath;
        ActorStats.MoveSpeed = MoveSpeed;
        ActorStats.AttackSpeed = AttackSpeed;
        ActorStats.DefaultAttackDamage = DefaultAttackDamage;
        PlayerChaser.AttackDistance = AttackDistance;
        PlayerChaser.OutRangeDistance = OutRangeDistance;
        PlayerChaser.PlayerTrans = PlayerTrans;


    }
    protected virtual void Start()
    {



        TakeDamage.textDmg = textDmg;
        animator = gameObject.GetComponent<Animator>();
        enemyStateMachine.Initialize(enemyIdleState);
    }
    protected virtual void Update()
    {
        currentHeath = gameObject.GetComponent<IActorStats>().currentHeath;
        CheckConditionToChangeState();
        attackCounter += Time.deltaTime;

        enemyStateMachine.CurrentEnemyState.FrameUpdate();

    }
    public void WhenDeath()
    {
        gameObject.SetActive(false);

    }

    public void CheckConditionToChangeState()
    {
        if (PlayerChaser.DistanceToPlayer > PlayerChaser.AttackDistance && animator.GetBool("isTakeDmg") == false && animator.GetBool("isDeath") == false)
        {
            enemyStateMachine.ChangeState(enemyIdleState);

        }
        else if (PlayerChaser.DistanceToPlayer <= PlayerChaser.AttackDistance && animator.GetBool("isTakeDmg") == false && attackCounter >= ActorStats.AttackSpeed)
        {

            attackCounter = 0f;
            enemyStateMachine.ChangeState(enemyAttackState);

        }
        if (ActorStats.currentHeath <= 0)
        {
            enemyStateMachine.ChangeState(enemyStateDeath);
        }
        if (ActorStats.currentHeath > 0)
        {
            enemyStateMachine.ChangeState(enemyIdleState);
        }

    }
    public void SetAnimationEndTakeDmg()
    {
        animator.SetBool("isTakeDmg", false);
    }
    public void SetAnimationEndAttack()
    {
        enemyStateMachine.ChangeState(enemyIdleState);

    }



    #endregion

}

