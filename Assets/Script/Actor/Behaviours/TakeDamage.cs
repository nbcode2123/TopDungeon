
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TakeDamage : MonoBehaviour
{
    public GameObject textDmg { get; set; }
    private Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }
    void Update()
    {
    }
    public void DealDmgToActor(float DamageTaken)
    {
        animator.SetBool("isTakeDmg", true);
        if (gameObject.GetComponent<IActorStats>().currentHeath >= DamageTaken)
        {
            gameObject.GetComponent<IActorStats>().currentHeath -= DamageTaken;
            ShowDmgTaken(DamageTaken);


        }
        if (gameObject.GetComponent<IActorStats>().currentHeath <= DamageTaken)
        {
            gameObject.GetComponent<IActorStats>().currentHeath = 0;


        }
    }
    public void ShowDmgTaken(float DamageTaken)
    {

        textDmg.GetComponent<TextMeshPro>().text = DamageTaken.ToString();
        Instantiate(textDmg, gameObject.transform.position, Quaternion.identity);




    }

}
