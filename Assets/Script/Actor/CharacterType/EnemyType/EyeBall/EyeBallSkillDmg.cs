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

        GameObject _otherGameobject = other.gameObject;
        _otherGameobject.GetComponent<TakeDamage>()?.DealDmgToActor(Damage);
        gameObject.GetComponent<Animator>().Play("Disable");


    }
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);


    }

}
