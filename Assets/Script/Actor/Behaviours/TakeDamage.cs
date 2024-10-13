
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TakeDamage : MonoBehaviour
{
    private void Start()
    {

    }
    void Update()
    {
    }
    public void DealDmgToActor(float DamageTaken) // gaay dmg len nhan vat 
    {
        Debug.Log(gameObject.name + "bi dmg ");
        if (gameObject.GetComponent<IActorStats>().currentHeath >= DamageTaken)
        {
            gameObject.GetComponent<IActorStats>().currentHeath -= DamageTaken;
            gameObject.GetComponent<Animator>().SetBool("isTakeDmg", true);


        }
        if (gameObject.GetComponent<IActorStats>().currentHeath <= DamageTaken)
        {
            gameObject.GetComponent<IActorStats>().currentHeath = 0;


        }
    }


}
