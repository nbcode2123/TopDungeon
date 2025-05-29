using System;
using UnityEngine;

public class BlueStarAttack : RangeAttack
{
    public int bulletCount = 6; // Số viên đạn
    public float AngleRange = 360f;
    public float BulletSpeed = 5f;
    void Start()
    {
        Bullet.GetComponent<BulletWeapon>().Damage = gameObject.GetComponent<IAttackable>().AttackDamage;

    }

    public override void Attack()
    {
        float startAngle = -AngleRange / 2;
        float angleStep = AngleRange / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + (angleStep * i);
            Quaternion rotationDirection = Quaternion.Euler(0, 0, angle);

            // GameObject bullet = Instantiate(Bullet, transform.position, rotation);
            GameObject bullet = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
            bullet.transform.rotation = rotationDirection;
            bullet.transform.position = gameObject.transform.position;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = rotationDirection * Vector2.right * BulletSpeed;
        }
        OnAttackInvoke();
    }


}
