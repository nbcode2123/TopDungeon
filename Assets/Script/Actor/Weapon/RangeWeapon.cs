using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{

    public Vector3 MousePos { get; set; }
    public GameObject Bullet;
    public float speedRotate = 10;
    public float speedBullet = 5;
    private GameObject _tempBullet;



    public override void Attack()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        // Chuyển đổi từ screen space sang world space
        MousePos = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 vectorToTarget = MousePos - gameObject.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion q2 = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, q2, speedRotate);
        if (Input.GetKeyDown(GameManager.Instance.AttackButton) == true)
        {
            _tempBullet = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);

            _tempBullet.transform.position = gameObject.transform.position;
            _tempBullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, speedRotate);
            _tempBullet.SetActive(true);
            Rigidbody2D rb = _tempBullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(vectorToTarget.x, vectorToTarget.y).normalized * speedBullet;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Bullet.GetComponent<BulletWeapon>().Damage = WeaponDamage;
        Bullet.GetComponent<BulletWeapon>().Speed = WeaponAttackSpeed;
        ObjectPoolManager.Instance.CreatePoolForObject(Bullet);
        ObjectPoolManager.Instance.SpawnThePool(Bullet.name, 10);


    }

    // Update is called once per frame
    void Update()
    {
        // Attack();

    }
    public void CreateAmmo()
    {
        ObjectPoolManager.Instance.CreatePoolForObject(Bullet);
        ObjectPoolManager.Instance.SpawnThePool(Bullet.name, 10);
    }


}
