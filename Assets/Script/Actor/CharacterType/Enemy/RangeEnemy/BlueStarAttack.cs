using System;
using UnityEngine;

public class BlueStarAttack : RangeAttack
{
    public GameObject Bullet;
    public int bulletCount = 6; // Số viên đạn
    public float AngleRange = 360f;
    public float BulletSpeed = 5f;
    void Start()
    {
        Bullet.GetComponent<BulletWeapon>().Damage = gameObject.GetComponent<CharactorStats>().AttackDamage;
    }

    public override void Attack()
    {
        float startAngle = -AngleRange / 2;
        float angleStep = AngleRange / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + (angleStep * i);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(Bullet, transform.position, rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.right * BulletSpeed;
        }
        OnAttackInvoke();
    }


}
