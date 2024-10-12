
using UnityEngine;


[RequireComponent(typeof(TakeDamage))]
public abstract class Enemy : MonoBehaviour
{

    [Header("Enemy State ")]
    public float MaxHeath;
    public float currentHeath;
    public float MoveSpeed;
    public float AttackSpeed;
    public float DefaultAttackDamage;

    [Header("Take Damge")]
    public GameObject textDmg;





    #region Enemy base properties 
    // public EnemyState enemyState { get; set; }
    // public EnemyStateMachine enemyStateMachine { get; set; }
    // public EnemyAttackState enemyAttackState { get; set; }
    // public EnemyIdleState enemyIdleState { get; set; }
    // public EnemyStateDeath enemyStateDeath { get; set; }
    // public float attackCounter;
    public Rigidbody2D RB { get; set; }
    public Animator animator { get; set; }
    private TakeDamage TakeDamage;
    private IActorStats ActorStats;



    #endregion







    #region Enemy Base Methods 
    protected virtual void Awake()
    {
        // enemyStateMachine = new EnemyStateMachine();
        // enemyIdleState = new EnemyIdleState(this, enemyStateMachine);
        // enemyAttackState = new EnemyAttackState(this, enemyStateMachine);
        // enemyStateDeath = new EnemyStateDeath(this, enemyStateMachine);
        ActorStats = gameObject.GetComponent<IActorStats>();
        TakeDamage = gameObject.GetComponent<TakeDamage>();


        ActorStats.MaxHeath = MaxHeath;
        ActorStats.currentHeath = MaxHeath;
        ActorStats.MoveSpeed = MoveSpeed;
        ActorStats.AttackSpeed = AttackSpeed;
        ActorStats.DefaultAttackDamage = DefaultAttackDamage;


    }
    protected virtual void Start()
    {



        TakeDamage.textDmg = textDmg;
        animator = gameObject.GetComponent<Animator>();
        // enemyStateMachine.Initialize(enemyIdleState);
    }
    protected virtual void Update()
    {
        currentHeath = gameObject.GetComponent<IActorStats>().currentHeath;
        // attackCounter += Time.deltaTime;

        // enemyStateMachine.CurrentEnemyState.FrameUpdate();

    }
    public void WhenDeath()
    {
        gameObject.SetActive(false);

    }


    public void SetAnimationEndTakeDmg()
    {
        animator.SetBool("isTakeDmg", false);
    }
    public void SetAnimationEndAttack()
    {
        animator.SetBool("isAttack", false);
        // enemyStateMachine.ChangeState(enemyIdleState);

    }




    #endregion

}

