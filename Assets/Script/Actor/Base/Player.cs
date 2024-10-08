
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

    private PlayerStats PlayerStats;
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
        PlayerStats = gameObject.GetComponent<PlayerStats>();
        TakeDamage = gameObject.GetComponent<TakeDamage>();
        PlayerStates = gameObject.GetComponent<PlayerStates>();


    }
    // Start is called before the first frame update
    protected virtual void Start()
    {


        currentHeath = MaxHeath;
        PlayerStats.MaxHeath = MaxHeath;
        PlayerStats.currentHeath = MaxHeath;
        PlayerStats.MoveSpeed = MoveSpeed;
        PlayerStats.AttackSpeed = AttackSpeed;
        PlayerStats.DefaultAttackDamage = DefaultAttackDamage;
        PlayerStats.CharacterRangeAttack = CharacterRangeAttack;
        PlayerStats.RangeAttackIcon = RangeAttackIcon;
        PlayerStats.BasicAttackName = BasicAttackName;
        PlayerStats.BasicAttackIcon = BasicAttackIcon;
        PlayerStats.ActorName = ActorName;

        PlayerStates.StateMachine = StateMachine;
        PlayerStates.IdleState = IdleState;
        PlayerStates.RunState = RunState;
        PlayerStates.AttackState = AttackState;
        PlayerStates.DeathState = DeathState;



        TakeDamage.textDmg = textDmg;

        animator = gameObject.GetComponent<Animator>();

        StateMachine.Initialize(IdleState);


    }
    protected virtual void Update()
    {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        currentHeath = gameObject.GetComponent<IActorStats>().currentHeath;

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
