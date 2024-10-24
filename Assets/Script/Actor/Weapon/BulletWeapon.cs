using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]


public class BulletWeapon : MonoBehaviour
{
    public float Damage { get; set; }
    public float Speed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerBullet");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        other.gameObject.GetComponent<TakeDamage>()?.DealDmgToActor(Damage);
        gameObject.SetActive(false);


    }

}
