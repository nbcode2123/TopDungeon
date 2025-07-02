using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeSkill : MonoBehaviour
{
    // public GameObject Spike;
    // public float TimeDelayEachSpike;
    // public float RangeSpawner;
    // public GameObject CenterPos;
    public int Damage;
    public Animator animator;
    public float TimeDelayDestroy = 2f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != gameObject)
        {
            other.gameObject.GetComponent<IDamageable>()?.TakeDamage(Damage);

        }
    }



    // Start is called before the first frame update
    void Start()
    {
        animator.Play("Idle");


    }


    // Update is called once per frame
    void Update()
    {

    }
    public void DealDamage()
    {


        StartCoroutine(DestroyObjDelay());

    }
    public IEnumerator DestroyObjDelay()
    {
        yield return new WaitForSeconds(TimeDelayDestroy);
        Destroy(gameObject);
    }

}
