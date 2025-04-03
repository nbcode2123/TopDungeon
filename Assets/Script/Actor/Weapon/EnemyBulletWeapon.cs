using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletWeapon : BulletWeapon
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void CheckObjectTrigger(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            // gameObject.SetActive(false);

        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            // gameObject.SetActive(false);

            other.gameObject.GetComponent<IDamageable>()?.TakeDamage(Damage);
        }



    }
}
