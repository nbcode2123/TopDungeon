using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChaser : MonoBehaviour
{

    public float AttackDistance { get; set; }
    public float OutRangeDistance { get; set; }
    public GameObject PlayerTrans { get; set; }
    public Vector2 moveDirection { get; set; }
    public float DistanceToPlayer { get; set; }
    public bool IsFaceingRight { get; set; } = true;


    // Start is called before the first frame update
    void Start()
    {

        PlayerTrans = GameManager.Instance.Player;// tam thoi 

    }

    // Update is called once per frame
    void Update()
    {

        // FollowPlayer();

    }
    public Vector2 FollowPlayer()
    {
        // DistanceToPlayer = Vector2.Distance(gameObject.transform.position, PlayerTrans.transform.position);
        moveDirection = new Vector2(PlayerTrans.transform.position.x - gameObject.transform.position.x, PlayerTrans.transform.position.y - gameObject.transform.position.y);
        moveDirection.Normalize();
        // if (DistanceToPlayer > AttackDistance && DistanceToPlayer < OutRangeDistance)
        // {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, PlayerTrans.transform.position, gameObject.GetComponent<IActorStats>().MoveSpeed * Time.deltaTime);
        if (moveDirection.x > 0 && !IsFaceingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFaceingRight = !IsFaceingRight;


        }
        if (moveDirection.x < 0 && IsFaceingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFaceingRight = !IsFaceingRight;
        }

        // }
        // else if ((DistanceToPlayer > OutRangeDistance || DistanceToPlayer <= AttackDistance) && moveDirection.x > 0)
        // {
        //     moveDirection = Vector2.zero;
        // }
        // else if ((DistanceToPlayer > OutRangeDistance || DistanceToPlayer <= AttackDistance) && moveDirection.x < 0)
        // {
        //     moveDirection = Vector2.zero;
        // }
        return moveDirection;

    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, OutRangeDistance);
        Gizmos.DrawWireSphere(gameObject.transform.position, AttackDistance);

    }


}
