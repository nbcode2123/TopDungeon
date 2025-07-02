using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTurretShootSystem : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed = 8f;
    public float TimeDelay = 1;
    private Coroutine ShootCoroutine;
    public void SetBullet(GameObject gameObject)
    {
        Bullet = gameObject;
    }
    public void UnSetBullet()
    {
        Bullet = null;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartCoroutineAttack(GameObject Target)
    {

        ShootCoroutine = StartCoroutine(ShootTarget(Target));
    }
    public void StopCoroutineAttack()
    {
        if (ShootCoroutine != null)
        {
            StopCoroutine(ShootCoroutine);

        }
    }
    public IEnumerator ShootTarget(GameObject Target)
    {
        while (true)
        {
            ShootMechanic(Target);
            yield return new WaitForSeconds(TimeDelay);

        }

    }
    public void ShootMechanic(GameObject Target)
    {

        var _direction = (Target.transform.position - gameObject.transform.position).normalized;

        Debug.Log(_direction);
        GameObject bullet = ObjectPoolManager.Instance.GetObjectFromPool(Bullet.name);
        // GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = gameObject.transform.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = _direction * BulletSpeed;


    }

}
