using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject Weapon;
    private IEnemyWeapon IEnemyWeapon;
    private GameObject TargetPlayer;
    private Action OnAttack;
    public void SetTargetPlayer(GameObject target)
    {
        TargetPlayer = target;
        IEnemyWeapon.SetTargetPlayer(target);
    }
    public void UnSetTargetPlayer()
    {
        TargetPlayer = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        IEnemyWeapon = Weapon.GetComponent<IEnemyWeapon>();
        OnAttack += IEnemyWeapon.AttackInvoke;


    }
    public void InvokeAttackWeapon()
    {
        OnAttack.Invoke();
    }
    public void DisableWeapon()
    {
        Weapon.SetActive(false);
    }
    public GameObject GetWeapon()
    {
        return Weapon;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
