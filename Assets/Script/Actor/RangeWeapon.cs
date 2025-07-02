
using UnityEngine;

public class RangeWeapon : MonoBehaviour, IRangeWeapon
{
    public Vector3 MousePos { get; set; }
    public int id;
    public int Id
    {
        get => id;
        set => id = value;
    }
    public int weaponDamage;
    public int WeaponDamage
    {
        get => weaponDamage;
        set => weaponDamage = value;
    }

    public float weaponAttackSpeed;
    public float WeaponAttackSpeed
    {
        get => weaponAttackSpeed;
        set => weaponAttackSpeed = value;
    }


    public GameObject bullet;
    public GameObject Bullet
    {
        get => bullet;
        set => bullet = value;

    }
    protected float SpeedRotate = 10;
    public float speedBullet;
    public float SpeedBullet
    {
        get => speedBullet;
        set => speedBullet = value;
    }
    private float tempAngle = 90;
    protected float AttackCounter = 0;
    public Camera CurrentCamera;
    [field: SerializeField] public bool ActiveWeapon { get; set; } = false;
    public int weaponEnergy;
    public int WeaponEnergy
    {
        get => weaponEnergy;
        set => weaponEnergy = value;
    }


    public int PoolBulletNumber = 20;

    public virtual void Attack()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 vectorToTarget = MousePos - gameObject.transform.position;
        if (GameManager.Instance.Player.GetComponent<PlayerStats>().CurrentEnergy >= WeaponEnergy)
        {
            if (AttackCounter >= WeaponAttackSpeed)
            {
                ShootBullet(vectorToTarget);
                GameManager.Instance.Player.GetComponent<PlayerStats>().DecreaseCurrentEnergy(WeaponEnergy);
            }

        }




    }
    public void Start()
    {
        CurrentCamera = GameManager.Instance.Camera;
    }
    public void Update()
    {
        if (ActiveWeapon == true)
        {
            AttackCounter += Time.deltaTime;
            SpinWeaponFollowCursor();

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
    public void EnableWeapon()
    {
        ActiveWeapon = true;
        gameObject.tag = "WeaponPlayer";


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


    public void DisableWeapon()
    {
        gameObject.transform.rotation = Quaternion.identity;
        ActiveWeapon = false;
        gameObject.tag = "Weapon";
    }
    public void CreateAmmo()
    {
        ObjectPoolManager.Instance.CreatePoolForDuplicateObject(Bullet);
        ObjectPoolManager.Instance.SpawnThePool(Bullet.name, PoolBulletNumber);
        // ObjectPoolManager.Instance.DontDestroyPool(Bullet.name);
    }
    public virtual void SpinWeaponFollowCursor()
    {
        if (CurrentCamera != null)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            MousePos = CurrentCamera.ScreenToWorldPoint(mouseScreenPosition);
            Vector3 vectorToTarget = MousePos - gameObject.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q2 = Quaternion.AngleAxis(angle - tempAngle, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, q2, SpeedRotate);
        }



    }
    public virtual void ShootBullet(Vector3 targetCursor)
    {
        if (AttackCounter >= WeaponAttackSpeed)
        {
            ObserverManager.Notify("Audio", "WandShoot");
            float angle = Mathf.Atan2(targetCursor.y, targetCursor.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            var _tempBullet = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
            _tempBullet.transform.position = gameObject.transform.position;
            _tempBullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, SpeedRotate);
            Bullet.GetComponent<BulletWeapon>().Damage = WeaponDamage;
            _tempBullet.SetActive(true);
            Rigidbody2D rb = _tempBullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(targetCursor.x, targetCursor.y).normalized * SpeedBullet;

            AttackCounter = 0;
        }


    }



}
