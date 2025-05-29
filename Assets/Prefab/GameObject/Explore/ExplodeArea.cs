using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeArea : MonoBehaviour
{

    public int Damage = 10;
    public Animator animator;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        other.gameObject.GetComponent<IDamageable>()?.TakeDamage(Damage);

    }

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        animator.GetComponent<Animator>().Play("Idle");

    }
    public void EndExplode()
    {
        gameObject.SetActive(false);
    }
}
