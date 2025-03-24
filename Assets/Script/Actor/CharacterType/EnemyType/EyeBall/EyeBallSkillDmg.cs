using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeBallSkillDmg : MonoBehaviour
{
    public LayerMask layerMask;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject _otherGameobject = other.gameObject;
        _otherGameobject.GetComponent<DamageCaculator>()?.TakeDamage(Damage);
        gameObject.GetComponent<Animator>().SetBool("isDisable", true);


    }
    public void SetActiveFalse()
    {
        gameObject.GetComponent<Animator>().SetBool("isDisable", false);
        gameObject.SetActive(false);


    }

}
