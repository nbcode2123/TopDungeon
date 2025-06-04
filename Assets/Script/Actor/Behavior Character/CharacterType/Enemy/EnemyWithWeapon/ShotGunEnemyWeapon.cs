using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunEnemyWeapon : RangeEnemyWeapon
{
    // public override void AttackInvoke()
    // {
    //     LockToPlayer();
    // }
    // protected override void LockToPlayer()
    // {
    //     // Copy đoạn code của LockToPlayer ở lớp cha,
    //     // và gọi ShootBullet (này sẽ là override)

    //     MoveAround();

    //     if (TargetPlayer != null)
    //     {
    //         if (TargetPlayer.transform.position.x > gameObject.transform.position.x && !isFacingRight)
    //         {
    //             gameObject.transform.localScale = new Vector3(1, 1, 1);
    //             isFacingRight = !isFacingRight;
    //         }
    //         else if (TargetPlayer.transform.position.x < gameObject.transform.position.x && isFacingRight)
    //         {
    //             gameObject.transform.localScale = new Vector3(-1, -1, 1);
    //             isFacingRight = !isFacingRight;
    //         }

    //         var _direction = (TargetPlayer.transform.position - gameObject.transform.position).normalized;

    //         float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
    //         Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
    //         gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, q, 10);

    //         ShootBullet(angle, _direction); // chắc chắn gọi hàm override ở lớp con
    //     }
    //     else
    //     {
    //         gameObject.transform.rotation = Quaternion.identity;
    //     }

    // }

    protected override void ShootBullet(float angle, Vector3 direction)
    {
        TimeCounter += Time.deltaTime;
        if (TargetPlayer != null && TimeCounter >= TimeBetweenEachShoot && Bullet != null)
        {
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = Pivot.transform.position;
            bullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, 10);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = q * Vector2.right * BulletSpeed;

            // 
            Quaternion qleft = Quaternion.AngleAxis(angle + 30, Vector3.forward);
            GameObject bullet1 = Instantiate(Bullet);
            bullet1.transform.position = Pivot.transform.position;
            bullet1.transform.rotation = Quaternion.Slerp(transform.rotation, qleft, 10);
            bullet1.SetActive(true);
            bullet1.GetComponent<Rigidbody2D>().velocity = qleft * Vector2.right * BulletSpeed;
            //
            Quaternion qright = Quaternion.AngleAxis(angle - 30, Vector3.forward);
            GameObject bullet2 = Instantiate(Bullet);
            bullet2.transform.position = Pivot.transform.position;
            bullet2.transform.rotation = Quaternion.Slerp(transform.rotation, qright, 10);
            bullet2.SetActive(true);
            bullet2.GetComponent<Rigidbody2D>().velocity = qright * Vector2.right * BulletSpeed;


            // 
            Quaternion qleft1 = Quaternion.AngleAxis(angle + 15, Vector3.forward);
            GameObject bullet11 = Instantiate(Bullet);
            bullet11.transform.position = Pivot.transform.position;
            bullet11.transform.rotation = Quaternion.Slerp(transform.rotation, qleft1, 10);
            bullet11.SetActive(true);
            bullet11.GetComponent<Rigidbody2D>().velocity = qleft1 * Vector2.right * BulletSpeed;
            //
            Quaternion qright2 = Quaternion.AngleAxis(angle - 15, Vector3.forward);
            GameObject bullet22 = Instantiate(Bullet);
            bullet22.transform.position = Pivot.transform.position;
            bullet22.transform.rotation = Quaternion.Slerp(transform.rotation, qright2, 10);
            bullet22.SetActive(true);
            bullet22.GetComponent<Rigidbody2D>().velocity = qright2 * Vector2.right * BulletSpeed;

            TimeCounter = 0;
        }




        // // 
        // Quaternion qleft1 = Quaternion.AngleAxis(angle + 60, Vector3.forward);
        // GameObject bullet3 = Instantiate(Bullet);
        // bullet3.transform.position = Pivot.transform.position;
        // bullet3.transform.rotation = Quaternion.Slerp(transform.rotation, qleft, 10);
        // bullet3.SetActive(true);
        // bullet3.GetComponent<Rigidbody2D>().velocity = qleft1 * Vector2.right * BulletSpeed;

        // Quaternion qright1 = Quaternion.AngleAxis(angle - 60, Vector3.forward);
        // GameObject bullet22 = Instantiate(Bullet);
        // bullet22.transform.position = Pivot.transform.position;
        // bullet22.transform.rotation = Quaternion.Slerp(transform.rotation, qright, 10);
        // bullet22.SetActive(true);
        // bullet22.GetComponent<Rigidbody2D>().velocity = qright1 * Vector2.right * BulletSpeed;
    }


}
