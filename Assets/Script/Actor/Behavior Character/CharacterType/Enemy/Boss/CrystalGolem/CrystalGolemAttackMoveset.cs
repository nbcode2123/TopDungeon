using System;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGolemAttackMoveset : MonoBehaviour
{

    public List<Action> AttackMoveset = new List<Action>();
    public GameObject CenterPos;
    public GameObject Bullet1;
    public int bulletCount = 10; // Số viên đạn
    public float AngleRange = 360f;
    public float BulletSpeed = 5f;
    public GameObject TargetPlayer;

    public void Start()
    {
        AttackMoveset.Add(Attack1);
        AttackMoveset.Add(Attack2);
        AttackMoveset.Add(Attack3);


    }
    public void Attack1()
    {

        float startAngle = -AngleRange / 2;
        float angleStep = AngleRange / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + (angleStep * i);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject bullet = Instantiate(Bullet1, CenterPos.transform.position, rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.right * BulletSpeed;
        }
    }
    public void Attack2()
    {

        var _direction = (TargetPlayer.transform.position - CenterPos.transform.position).normalized;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject bullet = Instantiate(Bullet1);
        bullet.transform.position = CenterPos.transform.position;
        bullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, 10);
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = q * Vector2.right * BulletSpeed;

        // 
        Quaternion qleft = Quaternion.AngleAxis(angle + 30, Vector3.forward);
        GameObject bullet1 = Instantiate(Bullet1);
        bullet1.transform.position = CenterPos.transform.position;
        bullet1.transform.rotation = Quaternion.Slerp(transform.rotation, qleft, 10);
        bullet1.SetActive(true);
        bullet1.GetComponent<Rigidbody2D>().velocity = qleft * Vector2.right * BulletSpeed;

        Quaternion qright = Quaternion.AngleAxis(angle - 30, Vector3.forward);
        GameObject bullet2 = Instantiate(Bullet1);
        //
        bullet2.transform.position = CenterPos.transform.position;
        bullet2.transform.rotation = Quaternion.Slerp(transform.rotation, qright, 10);
        bullet2.SetActive(true);
        bullet2.GetComponent<Rigidbody2D>().velocity = qright * Vector2.right * BulletSpeed;






    }
    public void Attack3()
    {
        StartCoroutine(gameObject.GetComponent<SpikeAttackSpawner>().Active());



    }
    public void AttackRamdomMoveSet()
    {
        AttackMoveset[UnityEngine.Random.Range(0, AttackMoveset.Count)].Invoke();
    }


}
