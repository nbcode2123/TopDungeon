using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour, IWeapon
{
    [field: SerializeField]
    public float WeaponDamage { get; set; }
    [field: SerializeField]
    public float WeaponAttackSpeed { get; set; }
    public Vector3 MousePos { get; set; }
    public GameObject Bullet;
    public float speedRotate = 10;
    public float speedBullet = 5;
    public GameObject _tempBullet;


    public void Attack()
    {
        if (Input.GetKeyDown(GameManager.Instance.AttackButton) == true)
        {
            _tempBullet = Bullet;
            Vector3 mouseScreenPosition = Input.mousePosition;
            // Chuyển đổi từ screen space sang world space
            MousePos = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            Vector3 vectorToTarget = MousePos - gameObject.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;


            // if (gameObject.transform.position.x > MousePos.x)
            // {
            //     _tempBullet.transform.localScale = new Vector3(-1, 1, 1);

            // }
            // else if (gameObject.transform.position.x < MousePos.x)
            // {
            //     // Lật sprite bằng cách thay đổi x trong quaternion
            //     _tempBullet.transform.localScale = new Vector3(-1, 1, 1); // Lật theo trục X

            // }

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);


            Bullet.transform.position = GameManager.Instance.Player.transform.position;
            Bullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, speedRotate);
            _tempBullet = Instantiate(Bullet);

            // transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedRotate);

            Rigidbody2D rb = _tempBullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(vectorToTarget.x, vectorToTarget.y).normalized * speedBullet;
        }









    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();

    }


}
