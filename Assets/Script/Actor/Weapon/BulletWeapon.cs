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
            gameObject.SetActive(false);
            SetActiveTimer = 0;
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        other.gameObject.GetComponent<TakeDamage>()?.DealDmgToActor(Damage);
        gameObject.SetActive(false);


    }

}
