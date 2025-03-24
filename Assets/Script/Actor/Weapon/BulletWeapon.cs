using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]


public class BulletWeapon : MonoBehaviour
{
    [field: SerializeField]
    public float Damage { get; set; }
    public float SetActiveTime = 5;
    private float SetActiveTimer = 0;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.activeSelf == true)
        {
            SetActiveTimer += Time.deltaTime;
        }
        if (SetActiveTimer >= SetActiveTime)
        {
            // gameObject.SetActive(false);
            Destroy(gameObject);
            SetActiveTimer = 0;
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.tag != "Floor")
        // {
        //     other.gameObject.GetComponent<IDamageable>()?.TakeDamage(Damage);
        //     gameObject.SetActive(false);
        // }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<IDamageable>().TakeDamage(Damage);
        }



    }

}
