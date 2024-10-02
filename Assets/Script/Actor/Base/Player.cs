
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(TakeDamage))]
[RequireComponent(typeof(PlayerStates))]
[RequireComponent(typeof(PlayerStats))]
public abstract class Player : MonoBehaviour
{
    [Tooltip("Actor Stats ")]
    [field: SerializeField]
    public float MaxHeath;
    public float currentHeath;
    public float MoveSpeed;
    public float AttackSpeed;
    public float DefaultAttackDamage;
    public string CharacterRangeAttack;
    public Sprite RangeAttackIcon;
    public string BasicAttackName;
    public Sprite BasicAttackIcon;
    public string ActorName;



    [Header("Take Damge")]
    public GameObject textDmg;


    #region Player properties
    protected Vector2 velocity;
    public PlayerStateMachine StateMachine { get; set; }
    public PlayerStateIdle IdleState { get; set; }
    public PlayerStateRun RunState { get; set; }
    public PlayerAttackState AttackState { get; set; }
    public PlayerDeathState DeathState { get; set; }
    protected float attackTimeCounter;
    public Animator animator { get; set; }

    private IActorStats ActorStats;
    private TakeDamage TakeDamage;
    private PlayerStates PlayerStates;
    public bool isDeath = false;


    #endregion



    #region Player Method
    void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerStateIdle(this, StateMachine);
        RunState = new PlayerStateRun(this, StateMachine);
        AttackState = new PlayerAttackState(this, StateMachine);
        DeathState = new PlayerDeathState(this, StateMachine);
        ActorStats = gameObject.GetComponent<IActorStats>();
        TakeDamage = gameObject.GetComponent<TakeDamage>();
        PlayerStates = gameObject.GetComponent<PlayerStates>();


    }
    // Start is called before the first frame update
    protected virtual void Start()
    {


        currentHeath = MaxHeath;
        ActorStats.MaxHeath = MaxHeath;
        ActorStats.currentHeath = MaxHeath;
        ActorStats.MoveSpeed = MoveSpeed;
        ActorStats.AttackSpeed = AttackSpeed;
        ActorStats.DefaultAttackDamage = DefaultAttackDamage;
        ActorStats.CharacterRangeAttack = CharacterRangeAttack;
        ActorStats.RangeAttackIcon = RangeAttackIcon;
        ActorStats.BasicAttackName = BasicAttackName;
        ActorStats.BasicAttackIcon = BasicAttackIcon;
        ActorStats.ActorName = ActorName;

        PlayerStates.StateMachine = StateMachine;
        PlayerStates.IdleState = IdleState;
        PlayerStates.RunState = RunState;
        PlayerStates.AttackState = AttackState;
        PlayerStates.DeathState = DeathState;

        // Attack.attackRange = attackRange;
        // Attack.AttackableLayer = attackableLayer;
        // Attack.AttackDmg = DefaultAttackDamage;

        TakeDamage.textDmg = textDmg;

        animator = gameObject.GetComponent<Animator>();

        StateMachine.Initialize(IdleState);


    }
    protected virtual void Update()
    {
        // Attack.attackTranform = attackTransform.transform;

        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;


        StateMachine.CurrentPlayerBaseState.FrameUpdate();



    }
    public void SetAnimationEndTakeDmg()
    {
        animator.SetBool("isTakeDmg", false);
    }
    public void ActorDeath()
    {
        PlayerStates.isDeath = true;
        animator.SetBool("isDeath", true);
        animator.speed = 0;



    }




    #endregion






}
