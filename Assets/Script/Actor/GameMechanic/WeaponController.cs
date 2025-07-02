using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject CurrentWeapon;
    public GameObject Player;
    private int CurrentWeaponEnergy;
    private PlayerStats PlayerStats;
    public static WeaponController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        ObserverManager.AddListener<GameObject>("Select Player Complete", ChoosingCharacterComplete);
        ObserverManager.AddListener<GameObject>("WeaponTriggerStay", LootWeapon);

    }
    public void ChoosingCharacterComplete(GameObject player)
    {
        Player = player;
        DefaultWeaponEquipment(player.GetComponent<PlayerStats>().BaseWeapon, player);
    }


    public void DefaultWeaponEquipment(GameObject weapon, GameObject player)
    {
        GameObject defaultWeapon = Instantiate(weapon);
        defaultWeapon.transform.SetParent(player.transform);
        defaultWeapon.transform.localPosition = Vector3.zero;
        defaultWeapon.GetComponent<IWeapon>().ActiveWeapon = true;
        Weapon1 = defaultWeapon;
        CurrentWeapon = defaultWeapon;
        defaultWeapon.GetComponent<RangeWeapon>()?.CreateAmmo();
        InputManager.Instance.RegisterOnAttack(Weapon1.GetComponent<IWeapon>().Attack);

    }
    public void LootWeapon(GameObject weapon)
    {
        if (Input.GetKeyDown(InputManager.Instance.TakeWeapon))
        {
            weapon.tag = "WeaponPlayer";

            Weapon1 = SwapWeaponInHand(Weapon1, weapon);
            CurrentWeapon = Weapon1;


        }




    }
    public GameObject SwapWeaponInHand(GameObject weaponHolding, GameObject weaponLooting)
    {

        weaponHolding.transform.position = weaponLooting.transform.position;
        weaponHolding.GetComponent<IWeapon>().DisableWeapon();
        weaponHolding.transform.SetParent(null);
        weaponLooting.transform.SetParent(Player.transform);
        weaponLooting.transform.localPosition = Vector3.zero;
        weaponLooting.GetComponent<IWeapon>().EnableWeapon();
        weaponLooting.GetComponent<RangeWeapon>()?.CreateAmmo();

        InputManager.Instance.UnRegisterOnAttack(weaponHolding.GetComponent<IWeapon>().Attack);
        InputManager.Instance.RegisterOnAttack(weaponLooting.GetComponent<IWeapon>().Attack);



        return weaponLooting;


    }
    public void ChangeWeapon()
    {
        if (Weapon2 != null && Weapon1 != null)
        {
            if (CurrentWeapon == Weapon1)
            {
                CurrentWeapon = Weapon2;
                TurnOnWeapon(Weapon2);
                TurnOffWeapon(Weapon1);
            }
            else
            {
                CurrentWeapon = Weapon1;
                TurnOnWeapon(Weapon1);
                TurnOffWeapon(Weapon2);
            }
        }

    }
    public void TurnOnWeapon(GameObject weapon)
    {
        weapon.SetActive(true);
        weapon.GetComponent<IWeapon>().ActiveWeapon = true;
        InputManager.Instance.RegisterOnAttack(weapon.GetComponent<IWeapon>().Attack);

    }
    public void TurnOffWeapon(GameObject weapon)
    {
        weapon.SetActive(false);
        weapon.GetComponent<IWeapon>().ActiveWeapon = false;
        InputManager.Instance.UnRegisterOnAttack(weapon.GetComponent<IWeapon>().Attack);

    }
    public void LoadWeaponData(GameObject weapon1)
    {
        if (Weapon1 != null)
        {
            TurnOffWeapon(Weapon1);
            Destroy(Weapon1);
        }
        if (Weapon2 != null)
        {
            TurnOffWeapon(Weapon2);
            Destroy(Weapon2);
        }

        GameObject _tempWeapon1 = Instantiate(weapon1);
        _tempWeapon1.transform.SetParent(Player.transform);
        _tempWeapon1.transform.localPosition = Vector3.zero;
        _tempWeapon1.GetComponent<IWeapon>().ActiveWeapon = true;
        _tempWeapon1.GetComponent<RangeWeapon>()?.CreateAmmo();
        Weapon1 = _tempWeapon1;
        TurnOnWeapon(Weapon1);

        CurrentWeapon = Weapon1;



    }
    public void TurnOffWeaponWhenLoading()
    {
        Weapon1.SetActive(false);
        Weapon1.GetComponent<IWeapon>().ActiveWeapon = false;
        InputManager.Instance.UnRegisterOnAttack(Weapon1.GetComponent<IWeapon>().Attack);
    }
    public void TurnOnWeaponWhenLoading()
    {
        Weapon1.SetActive(true);
        Weapon1.GetComponent<IWeapon>().ActiveWeapon = true;
        InputManager.Instance.RegisterOnAttack(Weapon1.GetComponent<IWeapon>().Attack);
    }
    public void Update()
    {
        if (Input.GetKeyDown(InputManager.Instance.ChangeWeapon))
        {
            // ChangeWeapon();
        }

    }



}
