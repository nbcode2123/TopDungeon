using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour, IWeapon
{
    public int weaponDamage;
    public float weaponAttackSpeed;
    public int weaponEnergy;
    public bool activeWeapon;
    public int id;
    public int WeaponDamage { get => weaponDamage; set => weaponDamage = value; }
    public float WeaponAttackSpeed { get => weaponAttackSpeed; set => weaponAttackSpeed = value; }
    public int WeaponEnergy { get => weaponEnergy; set => weaponEnergy = value; }
    public bool ActiveWeapon { get => activeWeapon; set => activeWeapon = value; }
    public int Id { get => id; set => id = value; }
    public GameObject DmgCollider;
    public Animator spearAnimator;
    public Animator spearEffectAnimator;
    public Camera CurrentCamera;
    public Vector3 MousePos { get; set; }
    public float AttackCounter;



    public void Attack()
    {
        KeyCode attackInput = InputManager.Instance.Attack;
        if (Input.GetKeyDown(attackInput))
        {
            if (AttackCounter >= WeaponAttackSpeed)
            {
                spearAnimator.Play("Attack");
                spearEffectAnimator.Play("Attack");
                AttackCounter = 0;
            }
        }



    }


    public void DisableWeapon()
    {
        gameObject.transform.rotation = Quaternion.identity;
        ActiveWeapon = false;
        gameObject.tag = "Weapon";
    }

    public void EnableWeapon()
    {
        ActiveWeapon = true;
        gameObject.tag = "WeaponPlayer";


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveWeapon == true)
        {
            AttackCounter += Time.deltaTime;
            SpinWeaponFollowCursor();


        }
        KeyCode attackInput = InputManager.Instance.Attack;

        if (Input.GetKeyUp(attackInput))
        {
            spearAnimator.Play("Idle");
            spearEffectAnimator.Play("Idle");
        }
        if (activeWeapon == false)
        {
            spearAnimator.Play("Idle");
            spearEffectAnimator.Play("Idle");
        }
    }
    protected void OnEnable()
    {
        ObserverManager.AddListener("DungeonStart", ChangeCamera);
        if (PropertyLobby.Instance != null)
        {
            CurrentCamera = PropertyLobby.Instance.Camera;

        }

    }
    public virtual void SpinWeaponFollowCursor()
    {
        if (CurrentCamera != null)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            MousePos = CurrentCamera.ScreenToWorldPoint(mouseScreenPosition);
            Vector3 vectorToTarget = MousePos - gameObject.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q2 = Quaternion.AngleAxis(angle, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, q2, 10);
        }



    }
    public void ChangeCamera()
    {
        if (GameManager.Instance.CurrentScene == "LobbyScene")
        {
            CurrentCamera = PropertyLobby.Instance.Camera;

        }
        else if (GameManager.Instance.CurrentScene == "DungeonScene")
        {
            CurrentCamera = PropertyDungeon.Instance.Camera;

        }
    }

    private void OnDestroy()
    {
        ObserverManager.RemoveListener("DungeonStart", ChangeCamera);

    }
    void OnDisable()
    {
        ObserverManager.RemoveListener("DungeonStart", ChangeCamera);
    }



}
