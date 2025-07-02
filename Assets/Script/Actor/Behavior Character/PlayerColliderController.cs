
using System;
using UnityEngine;

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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Wall": break;
            case "Floor":
                CheckEnterNewRoom(other.GetComponentInParent<RoomObject>().Index);
                break;
            case "Weapon":; break;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        switch (other.tag)
        {

            case "Weapon": ObserverManager.Notify("WeaponTriggerStay", other.gameObject); break;

        }

    }
    public void CheckEnterNewRoom(int roomIndex)
    {
        if (roomIndex != DungeonController.Instance.CurrentRoom)
        {

            ObserverManager.Notify("Enter New Room", roomIndex);

        }

    }
    public void WeaponTrigger(GameObject weapon)
    {

    }

}
