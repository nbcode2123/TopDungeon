using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallShooter : MonoBehaviour
{
    public GameObject Bullet;
    public float Speed = 1;
    private GameObject EyeBall;

    // Start is called before the first frame update
    void Start()
    {
        ObjectPoolManager.Instance.CreatePoolForObject(Bullet);
        ObjectPoolManager.Instance.SpawnThePool(Bullet.name, 10);

    }
    void Awake()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShootTheBall();
        }

    }
    public void ShootTheBall()
    {
        var _tempBullet = ObjectPoolManager.Instance.SingleObject(Bullet.name);

        _tempBullet.SetActive(true);
        _tempBullet.transform.position = gameObject.transform.position;
        _tempBullet.transform.rotation = gameObject.transform.rotation;

        var _tempDireciton = (GameManager.Instance.Player.transform.position - _tempBullet.transform.position).normalized;
        Debug.Log(_tempDireciton);

        Rigidbody2D rb = _tempBullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(_tempDireciton.x, _tempDireciton.y).normalized * Speed; // Bắn đạn theo hướng firePoint


    }
}
