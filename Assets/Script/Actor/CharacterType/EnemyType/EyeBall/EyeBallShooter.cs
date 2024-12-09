
using Script.GameManager;
using UnityEngine;

namespace Script.Actor.CharacterType.EnemyType.EyeBall
{
    public class EyeBallShooter : MonoBehaviour
    {
        public GameObject Bullet;
        public float SpeedBullet;
        public float Damage;
        public float attackcounter { get; set; }
        // Start is called before the first frame update
        public void OnEnable()
        {
            if (!ObjectPoolManager.Instance.ListPoolName.Contains(Bullet.name))
            {
                ObjectPoolManager.Instance.CreatePoolForObject(Bullet);
                ObjectPoolManager.Instance.SpawnThePool(Bullet.name, 30);
            }
            else return;


        }

        public void ShootTheBall()
        {
            var _tempBullet = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
            _tempBullet.SetActive(true);
            _tempBullet.transform.position = gameObject.transform.position;
            _tempBullet.transform.rotation = gameObject.transform.rotation;
            _tempBullet.GetComponent<EyeBallSkillDmg>().Damage = gameObject.GetComponent<EyeBallStats>().AttackDamage;

            var _tempDireciton = (GameManager.GameManager.Instance.Player.transform.position - _tempBullet.transform.position).normalized;

            Rigidbody2D rb = _tempBullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(_tempDireciton.x, _tempDireciton.y).normalized * SpeedBullet; // Bắn đạn theo hướng firePoint


        }


    }
}
