using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject CurrentWeapon;

    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeaponHolding();

    }
    void OnEnable()
    {

        GameObject _BaseWeapon = gameObject.GetComponent<PlayerStats>().BaseWeapon;
        Weapon1 = Instantiate(_BaseWeapon, gameObject.transform.position, Quaternion.identity);
        Weapon1.GetComponent<IWeapon>().ActiveWeapon = true;
        Weapon1.GetComponent<IRangeWeapon>()?.CreateAmmo();
        InputManager.Instance.OnAttack += Weapon1.GetComponent<IWeapon>().Attack;
        Weapon1.transform.SetParent(gameObject.transform);
        CurrentWeapon = Weapon1;

    }
    public void ChangeWeaponHolding()
    {
        if (Input.GetKeyDown(InputManager.Instance.ChangeWeapon))
        {
            if (Weapon2 != null && Weapon1 != null)
            {
                if (CurrentWeapon == Weapon2)
                {
                    Weapon1.SetActive(true);
                    Weapon2.SetActive(false);
                    CurrentWeapon = Weapon1;
                    InputManager.Instance.OnAttack -= Weapon2.GetComponent<IWeapon>().Attack;

                    InputManager.Instance.OnAttack += CurrentWeapon.GetComponent<IWeapon>().Attack;

                }
                else if (CurrentWeapon == Weapon1)
                {
                    Weapon1.SetActive(false);
                    Weapon2.SetActive(true);

                    CurrentWeapon = Weapon2;
                    InputManager.Instance.OnAttack -= Weapon1.GetComponent<IWeapon>().Attack;

                    InputManager.Instance.OnAttack += CurrentWeapon.GetComponent<IWeapon>().Attack;
                }


            }
        }
    }
    public void TakeWeapon(GameObject weapon)
    {
        if (Input.GetKeyDown(InputManager.Instance.TakeWeapon))
        {
            weapon.tag = "WeaponPlayer";

            if (Weapon2 == null)
            {
                Weapon1.SetActive(false);
                InputManager.Instance.OnAttack -= Weapon1.GetComponent<IWeapon>().Attack;
                Weapon2 = Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
                Weapon2.GetComponent<IWeapon>().ActiveWeapon = true;
                Weapon2.GetComponent<IRangeWeapon>()?.CreateAmmo();
                Weapon2.transform.SetParent(gameObject.transform);
                InputManager.Instance.OnAttack += Weapon2.GetComponent<IWeapon>().Attack;
                CurrentWeapon = Weapon2;
                Destroy(weapon);


            }
            else if (Weapon1 != null && Weapon2 != null)
            {
                SwapWeapon(CurrentWeapon, weapon);











            }
        }

    }
    public void SwapWeapon(GameObject weaponPlayer, GameObject weaponOutside)
    {
        var _tempPosition = weaponOutside.transform.position;
        weaponOutside.transform.SetParent(gameObject.transform);
        weaponOutside.GetComponent<IWeapon>().EnableWeapon();
        InputManager.Instance.OnAttack += weaponOutside.GetComponent<IWeapon>().Attack;

        weaponPlayer.transform.parent = null;
        weaponPlayer.GetComponent<IWeapon>().DisableWeapon();
        InputManager.Instance.OnAttack -= weaponPlayer.GetComponent<IWeapon>().Attack;
        weaponPlayer.transform.position = _tempPosition;

        Weapon2 = weaponOutside;












    }
}
