using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [RequireComponent(typeof(Rigidbody2D))]
// [RequireComponent(typeof(Animator))]


public class BulletWeapon : MonoBehaviour
{
    [field: SerializeField]
    public int Damage { get; set; }
    public float SetActiveTime = 5;
    public Action OnDisable;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        StartCoroutine(TimeSetDisable());

    }

    // Update is called once per frame
    void Update()
    {




    }
    public IEnumerator TimeSetDisable()
    {
        yield return new WaitForSeconds(SetActiveTime);
        gameObject.SetActive(false);
        OnDisable?.Invoke();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.tag != "Floor")
        // {
        //     other.gameObject.GetComponent<IDamageable>()?.TakeDamage(Damage);
        //     gameObject.SetActive(false);
        // }
        CheckObjectTrigger(other);



    }
    public virtual void CheckObjectTrigger(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
            OnDisable?.Invoke();


        }
        if (other.gameObject.tag == "Enemy")
        {
            // Destroy(gameObject);
            OnDisable?.Invoke();
            other.gameObject.GetComponent<IDamageable>()?.TakeDamage(Damage);
            gameObject.SetActive(false);

        }




    }


}
