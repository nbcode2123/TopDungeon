using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttacker : MonoBehaviour, IAttack
{
    public LayerMask AttackableLayer { get; set; }
    public float AttackDmg { get; set; }
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
