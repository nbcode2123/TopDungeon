
using UnityEngine;

public class RangeWeapon : MonoBehaviour, IWeapon
{
    public Vector3 MousePos { get; set; }
    [field: SerializeField] public float WeaponDamage { get; set; }
    [field: SerializeField] public float WeaponAttackSpeed { get; set; }
    public GameObject Bullet;
    private float SpeedRotate = 10;
    [SerializeField] private float SpeedBullet = 10;
    private float tempAngle = 90;
    private float AttackCounter = 0;
    public Camera Camera;

    public void Attack()
    {

        Vector3 mouseScreenPosition = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 vectorToTarget = MousePos - gameObject.transform.position;
        if (AttackCounter >= WeaponAttackSpeed)
        {
            ShootBullet(vectorToTarget);
        }


    }
    void OnEnable()
    {
        ObserverManager.AddListener("DungeonStart", ChangeCamera);
        Camera = GameManager.Instance.Camera;
    }
    public void ChangeCamera()
    {
        Camera = PropertyDungeon.Instance.Camera;
    }
    void OnDisable()
    {
        ObserverManager.RemoveListener("DungeonStart", ChangeCamera);
    }

    void Update()
    {
        AttackCounter += Time.deltaTime;
        SpinWeaponFollowCursor();

    }
    public void CreateAmmo()
    {
        ObjectPoolManager.Instance.CreatePoolForDuplicateObject(Bullet);
        ObjectPoolManager.Instance.SpawnThePool(Bullet.name, 10);
        ObjectPoolManager.Instance.DontDestroyPool(Bullet.name);
    }
    public void SpinWeaponFollowCursor()
    {
        if (Camera != null)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            MousePos = Camera.ScreenToWorldPoint(mouseScreenPosition);
            Vector3 vectorToTarget = MousePos - gameObject.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q2 = Quaternion.AngleAxis(angle - tempAngle, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, q2, SpeedRotate);
        }

    }
    public void ShootBullet(Vector3 targetCursor)
    {
        if (AttackCounter >= WeaponAttackSpeed)
        {
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
