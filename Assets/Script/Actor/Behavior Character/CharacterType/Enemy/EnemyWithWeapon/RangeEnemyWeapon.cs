using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyWeapon : MonoBehaviour, IEnemyWeapon
{
    [SerializeField] protected bool isFacingRight = true;
    [SerializeField] protected GameObject Pivot;
    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected float TimeBetweenEachShoot;
    [SerializeField] protected GameObject Actor;
    [SerializeField] protected float BulletSpeed;
    private Vector2 RandomDirection;
    protected float TimeCounter;
    private float MoveSpeed;
    public GameObject TargetPlayer { get; set; }
    public Rigidbody2D rb;
    public virtual void AttackInvoke()
    {
        LockToPlayer();
    }
    public void SetTargetPlayer(GameObject target)
    {
        TargetPlayer = target;
    }
    public void UnSetTargetPlayer()
    {
        TargetPlayer = null;
    }
    protected void MoveAround()
    {
        rb.MovePosition(rb.position + RandomDirection * MoveSpeed * Time.deltaTime);


    }
    protected virtual void LockToPlayer()
    {
        MoveAround();

        if (TargetPlayer != null)
        {
            if (TargetPlayer.transform.position.x > gameObject.transform.position.x && !isFacingRight)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                isFacingRight = !isFacingRight;

            }
            else if (TargetPlayer.transform.position.x < gameObject.transform.position.x && isFacingRight)
            {
                gameObject.transform.localScale = new Vector3(-1, -1, 1);
                isFacingRight = !isFacingRight;
            }
            var _direction = (TargetPlayer.transform.position - gameObject.transform.position).normalized;



            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, q, 10);
            ShootBullet(angle, _direction);
        }
        else if (TargetPlayer == null)
        {
            gameObject.transform.rotation = Quaternion.identity;
        }




    }
    protected virtual void ShootBullet(float angle, Vector3 direction)
    {
        TimeCounter += Time.deltaTime;
        if (TargetPlayer != null && TimeCounter >= TimeBetweenEachShoot && Bullet != null)
        {
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            GameObject _bullet = Instantiate(Bullet);
            _bullet.transform.position = Pivot.transform.position;
            _bullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, 10);
            _bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed;
            TimeCounter = 0;
        }
    }
    public void Update()
    {
        // LockToPlayer();
    }
    public void Start()
    {
        Bullet = Actor.GetComponent<RangeAttack>().Bullet;
        rb = Actor.GetComponent<Rigidbody2D>();
        MoveSpeed = Actor.GetComponent<IMovement>().GetMovementSpeed();
        RandomDirection = Random.insideUnitCircle.normalized;




    }
}


