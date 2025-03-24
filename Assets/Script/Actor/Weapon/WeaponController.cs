using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject ActorWeapon;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnEnable()
    {
        ActorWeapon = gameObject.GetComponent<PlayerStats>().BaseWeapon;
        InitializeWeapon();


    }
    public void InitializeWeapon()
    {
        if (ActorWeapon != null)
        {
            ActorWeapon = Instantiate(ActorWeapon);
            InputManager.Instance.OnAttack += ActorWeapon.GetComponent<IWeapon>().Attack;
            ActorWeapon.transform.SetParent(gameObject.transform);
            ActorWeapon.transform.position = gameObject.transform.position;
            ActorWeapon.GetComponent<BoxCollider2D>().enabled = false;
            ActorWeapon.GetComponent<RangeWeapon>()?.CreateAmmo();

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeActorWeapon(GameObject newWeapon)
    {
        UnEquipWeapon(newWeapon);
        EquipWeapon(newWeapon);

    }
    public void UnEquipWeapon(GameObject newWeapon)
    {

        if (ActorWeapon != null)
        {
            InputManager.Instance.OnAttack -= ActorWeapon.GetComponent<IWeapon>().Attack;
            ActorWeapon.transform.position = newWeapon.transform.position;
            ActorWeapon.transform.rotation = Quaternion.identity;
            ActorWeapon.transform.parent = null;
            ActorWeapon.GetComponent<BoxCollider2D>().enabled = true;
            if (ActorWeapon.GetComponent<RangeWeapon>() != null)
            {
                ObjectPoolManager.Instance.ClearPoolObject(ActorWeapon.GetComponent<RangeWeapon>().Bullet.name);
            }
        }

    }
    public void EquipWeapon(GameObject newWeapon)
    {
        ActorWeapon = newWeapon;
        InputManager.Instance.OnAttack += ActorWeapon.GetComponent<IWeapon>().Attack;
        ActorWeapon.transform.SetParent(gameObject.transform);
        ActorWeapon.transform.position = gameObject.transform.position;
        InputManager.Instance.OnAttack += ActorWeapon.GetComponent<IWeapon>().Attack;
        ActorWeapon.GetComponent<BoxCollider2D>().enabled = false;
        if (ActorWeapon.GetComponent<RangeWeapon>() != null)
        {
            ActorWeapon.GetComponent<RangeWeapon>().CreateAmmo();

        }

    }



}
