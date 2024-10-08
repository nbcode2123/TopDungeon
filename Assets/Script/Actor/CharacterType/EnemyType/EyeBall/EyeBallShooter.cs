using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallShooter : MonoBehaviour
{
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Bullet);
        ObjectPoolManager.Instance.CreatePoolForObject(Bullet);
        ObjectPoolManager.Instance.SpawnThePool(Bullet.name, 10, gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
