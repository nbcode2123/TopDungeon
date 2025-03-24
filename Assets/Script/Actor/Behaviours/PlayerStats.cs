using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharactorStats
{
    [SerializeField] public GameObject BaseWeapon;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // gameObject.GetComponent<WeaponController>().ActorWeapon = BaseWeapon;
        // gameObject.GetComponent<WeaponController>().InitializeWeapon();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
