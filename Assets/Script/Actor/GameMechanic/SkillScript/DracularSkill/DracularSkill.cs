using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracularSkill : MonoBehaviour
{
    public Animator Animator;
    public int Damage = 5;
    public float TimeDelay = 1f;
    public GameObject DamageArea;
    public GameObject BlackHoleArea;


    // Start is called before the first frame update
    void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
        DamageArea.GetComponent<DamageArea>().Damage = Damage;
        DamageArea.GetComponent<DamageArea>().TimeDelay = TimeDelay;
        BlackHoleArea.GetComponent<BlackHoleArea>().animator = Animator;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
