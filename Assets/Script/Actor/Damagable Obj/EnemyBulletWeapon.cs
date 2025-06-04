
using UnityEngine;

public class EnemyBulletWeapon : BulletWeapon
{
    private bool isHasPoolObj;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        // isHasPoolObj = ObjectPoolManager.Instance.CheckForPoolExistence(gameObject.name);

    }

    // Update is called once per frame
    void Update()
    {


    }
    public override void CheckObjectTrigger(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (isHasPoolObj)
            {
                gameObject.SetActive(false);

            }
            else if (isHasPoolObj == false)
            {
                Destroy(gameObject);

            }

        }
        if (other.gameObject.tag == "Player")
        {
            if (isHasPoolObj)
            {
                gameObject.SetActive(false);

            }
            else if (isHasPoolObj == false)
            {
                Destroy(gameObject);

            }

            other.gameObject.GetComponent<IDamageable>()?.TakeDamage(Damage);
        }



    }


}
