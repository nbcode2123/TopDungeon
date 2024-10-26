using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActorWeapon : MonoBehaviour
{
    public GameObject actorWeapon = null;




    // Start is called before the first frame update
    void Start()
    {
        // if (actorWeapon != null)
        // {
        //     actorWeapon = Instantiate(actorWeapon, gameObject.transform);
        //     actorWeapon.transform.SetParent(gameObject.transform);
        //     actorWeapon.transform.position = gameObject.transform.position;
        //     actorWeapon.GetComponent<BoxCollider2D>().enabled = false;


        // }

    }

    // Update is called once per frame
    void Update()
    {
        if (actorWeapon != null)
        {
            actorWeapon.GetComponent<IWeapon>()?.Attack();

        }




    }
    public void ChangeActorWeapon(GameObject newActorWeapon)
    {
        if (actorWeapon != null)
        {
            actorWeapon.transform.position = newActorWeapon.transform.position;
            actorWeapon.transform.rotation = Quaternion.identity;
            actorWeapon.transform.parent = null;
            actorWeapon.GetComponent<BoxCollider2D>().enabled = true;
            if (actorWeapon.GetComponent<RangeWeapon>() != null)
            {
                ObjectPoolManager.Instance.RemovePool(actorWeapon.GetComponent<RangeWeapon>().Bullet.name);

            }
        }


        actorWeapon = newActorWeapon;
        actorWeapon.transform.SetParent(gameObject.transform);
        actorWeapon.transform.position = gameObject.transform.position;
        actorWeapon.GetComponent<BoxCollider2D>().enabled = false;

        if (actorWeapon.GetComponent<RangeWeapon>() != null)
        {
            actorWeapon.GetComponent<RangeWeapon>().CreateAmmo();
        }




    }



}
