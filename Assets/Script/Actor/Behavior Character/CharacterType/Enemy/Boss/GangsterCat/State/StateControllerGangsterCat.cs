using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerGangsterCat : MonoBehaviour
{
    private IStateMachine stateMachine;
    private IState IdleState;
    private IState ShootState;
    private IState DeathState;
    private IState MoveState;
    private Animator animator;
    private Coroutine CombatPattern;
    private DetectPlayer DetectPlayer;
    [SerializeField] private GameObject TargetPlayer;
    [SerializeField] private GameObject DetectPlayerCollider;
    [SerializeField] private bool IsFaceingRight = true;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        stateMachine = new StateMachine2();
        IdleState = new IdleStateGangsterCat(gameObject, animator);
        ShootState = new ShootStateGangsterCat(gameObject, animator);
        DeathState = new DeathStateGangsterCat(gameObject, animator);
        MoveState = new MoveStateGangsterCat(gameObject, animator);
        stateMachine.Initialize(IdleState);
        DetectPlayer = DetectPlayerCollider.GetComponent<DetectPlayer>();
        DetectPlayer.RegisterOnDetectPlayer(SetTargetPlayer);
        gameObject.GetComponent<DamageCalculator>().OnDeath += ChangeToDeathState;
        // gameObject.GetComponent<DamageCalculator>().OnDeath += gameObject.GetComponent<EnemyMarkRoomIndex>().OnDeath;



    }
    public void SetTargetPlayer(GameObject target)
    {
        TargetPlayer = target;
        StartCoroutineCombatPattern();
    }
    public GameObject GetTargetPlayer()
    {
        return TargetPlayer;
    }
    public void ChangeToIdleState()
    {
        stateMachine.ChangeState(IdleState);
    }
    public void ChangeToShootState()
    {
        stateMachine.ChangeState(ShootState);
    }
    public void ChangeToDeathState()
    {
        stateMachine.ChangeState(DeathState);

    }
    public void ChangeToMoveState()
    {
        stateMachine.ChangeState(MoveState);

    }
    private void Update()
    {
        stateMachine.CurrentState.FrameUpdate();
        CheckForLeftOrRightFacing();
    }
    public void StartCoroutineCombatPattern()
    {
        CombatPattern = StartCoroutine(CombatPatternExcute());


    }
    public void StopCoroutineCombatPattern()
    {
        StopCoroutine(CombatPattern);
    }
    public IEnumerator CombatPatternExcute()
    {
        while (true)
        {
            yield return null;
            ChangeToIdleState();
            yield return new WaitForSeconds(3);
            ChangeToMoveState();
            yield return new WaitForSeconds(3);
            ChangeToShootState();
            yield return new WaitForSeconds(3);
        }

    }
    private void OnDisable()
    {
        DetectPlayer.UnRegisterOnDetectPlayer(SetTargetPlayer);
        gameObject.GetComponent<DamageCalculator>().OnDeath -= ChangeToDeathState;
        gameObject.GetComponent<DamageCalculator>().OnDeath -= gameObject.GetComponent<EnemyMarkRoomIndex>().OnDeath;

    }
    private void OnDestroy()
    {
        DetectPlayer.UnRegisterOnDetectPlayer(SetTargetPlayer);
        gameObject.GetComponent<DamageCalculator>().OnDeath -= ChangeToDeathState;
        gameObject.GetComponent<DamageCalculator>().OnDeath -= gameObject.GetComponent<EnemyMarkRoomIndex>().OnDeath;

    }
    public void CheckForLeftOrRightFacing()
    {
        if (TargetPlayer != null)
        {
            if (IsFaceingRight && TargetPlayer.transform.position.x < gameObject.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                IsFaceingRight = !IsFaceingRight;
            }
            else if (!IsFaceingRight && TargetPlayer.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                IsFaceingRight = !IsFaceingRight;

            }
        }
    }

}
