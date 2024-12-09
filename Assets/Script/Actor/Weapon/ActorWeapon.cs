using Script.GameManager;
using UnityEngine;

namespace Script.Actor.Weapon
{
    public class ActorWeapon : MonoBehaviour
    {
        public GameObject actorWeapon = null;
        public GameObject ObjectNull;




        // Start is called before the first frame update
        void Start()
        {

            ObjectNull = new GameObject();

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
                Debug.Log(actorWeapon.name);
                actorWeapon.transform.position = newActorWeapon.transform.position;
                actorWeapon.transform.rotation = Quaternion.identity;

                actorWeapon.transform.SetParent(ObjectNull.transform);
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
}
