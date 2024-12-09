using Script.Actor.Weapon;
using Script.GameManager;
using Script.GameManager.Dungeon;
using Script.GameManager.Logic;
using UnityEngine;

namespace Script.Actor.Behaviours
{
    public class PlayerColliderController : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
        }


        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D other)
        {
            gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            if (other.tag == "Weapon")
            {
                ObserverManager.Notify("EnterWeapon", new object[] { other.name, other.gameObject });


            }
            if (other.tag == "Floor")
            {
                var _roomIndex = other.gameObject.GetComponent<RoomControl>().Index;
                var isComplete = other.gameObject.GetComponent<RoomControl>().isComplete;
                if ((_roomIndex != PlayerLevelManager.Instance.PlayerRoom || _roomIndex != 1) && isComplete == false)
                {
                    PlayerLevelManager.Instance.PlayerRoom = _roomIndex;
                    ObserverManager.Notify("Enter New Room", _roomIndex);
                }
                else return;
            }
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Weapon")
            {
                ObserverManager.Notify("OutWeapon");

            }
        }
        public void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log(other.name);
            if (other.tag == "Weapon" && Input.GetKeyDown(InputManager.Instance.ActiveObject))
            {
                gameObject.GetComponent<ActorWeapon>().ChangeActorWeapon(other.gameObject);

            }


        }

    }
}
