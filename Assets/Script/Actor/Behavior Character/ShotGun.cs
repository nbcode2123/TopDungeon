using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : RangeWeapon
{


    public override void SpinWeaponFollowCursor()
    {
        if (CurrentCamera != null)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            MousePos = CurrentCamera.ScreenToWorldPoint(mouseScreenPosition);
            Vector3 vectorToTarget = MousePos - gameObject.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q2 = Quaternion.AngleAxis(angle, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, q2, SpeedRotate);
        }



    }
    public override void ShootBullet(Vector3 targetCursor)
    {
        if (AttackCounter >= WeaponAttackSpeed)
        {
            float angle = Mathf.Atan2(targetCursor.y, targetCursor.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            var _tempBullet = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
            _tempBullet.GetComponent<BulletWeapon>().Damage = WeaponDamage;

            _tempBullet.transform.position = gameObject.transform.position;
            _tempBullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, SpeedRotate);

            _tempBullet.SetActive(true);
            Rigidbody2D rb = _tempBullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(targetCursor.x, targetCursor.y).normalized * SpeedBullet;


            Quaternion qleft = Quaternion.AngleAxis(angle + 15, Vector3.forward);
            var bullet1 = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
            bullet1.GetComponent<BulletWeapon>().Damage = WeaponDamage;
            bullet1.transform.position = gameObject.transform.position;
            bullet1.transform.rotation = Quaternion.Slerp(transform.rotation, qleft, 10);
            bullet1.SetActive(true);
            bullet1.GetComponent<Rigidbody2D>().velocity = qleft * Vector2.right * SpeedBullet;
            //
            Quaternion qright = Quaternion.AngleAxis(angle - 15, Vector3.forward);
            var bullet2 = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
            bullet2.GetComponent<BulletWeapon>().Damage = WeaponDamage;
            bullet2.transform.position = gameObject.transform.position;
            bullet2.transform.rotation = Quaternion.Slerp(transform.rotation, qright, 10);
            bullet2.SetActive(true);
            bullet2.GetComponent<Rigidbody2D>().velocity = qright * Vector2.right * SpeedBullet;

            Quaternion qleft2 = Quaternion.AngleAxis(angle + 30, Vector3.forward);
            var bullet3 = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
            bullet3.GetComponent<BulletWeapon>().Damage = WeaponDamage;
            bullet3.transform.position = gameObject.transform.position;
            bullet3.transform.rotation = Quaternion.Slerp(transform.rotation, qleft2, 10);
            bullet3.SetActive(true);
            bullet3.GetComponent<Rigidbody2D>().velocity = qleft2 * Vector2.right * SpeedBullet;
            //
            Quaternion qright2 = Quaternion.AngleAxis(angle - 30, Vector3.forward);
            var bullet4 = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
            bullet4.GetComponent<BulletWeapon>().Damage = WeaponDamage;
            bullet4.transform.position = gameObject.transform.position;
            bullet4.transform.rotation = Quaternion.Slerp(transform.rotation, qright2, 10);
            bullet4.SetActive(true);
            bullet4.GetComponent<Rigidbody2D>().velocity = qright2 * Vector2.right * SpeedBullet;

            AttackCounter = 0;
        }


    }

}
