using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGolemAttackCombo : MonoBehaviour
{
    public Animator animator;
    public GameObject actor;
    private Coroutine coroutineAttack;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartCoroutineAttack()
    {
        coroutineAttack = StartCoroutine(AttackBehaviour());


    }
    public void StopCoroutineAttack()
    {
        StopCoroutine(coroutineAttack);
        coroutineAttack = null;
        Debug.Log("Stop Attack Combo");

    }
    public IEnumerator AttackBehaviour()
    {
        while (true)
        {
            animator.Play("Idle");
            Debug.Log("idle");
            yield return new WaitForSeconds(1.5f);
            yield return MoveToPlayer();
            animator.Play("Idle");
            yield return new WaitForSeconds(1.5f);
            animator.Play("Attack");
            yield return new WaitForSeconds(1.5f);

        }

    }
    public IEnumerator MoveToPlayer()
    {

        animator.Play("Move");
        var _targetPlayer = actor.GetComponent<CrystallGolemStateController>().TargetPlayer;
        Debug.Log(_targetPlayer.name);
        Vector2 _randomDirection = new Vector2(_targetPlayer.transform.position.x - actor.transform.position.x, _targetPlayer.transform.position.y - actor.transform.position.y).normalized;
        actor.GetComponent<Rigidbody2D>().velocity = _randomDirection * actor.GetComponent<CharacterStats>().GetMovementSpeed();
        yield return new WaitForSeconds(2f);
        actor.GetComponent<Rigidbody2D>().velocity = Vector3.zero;


    }
}
