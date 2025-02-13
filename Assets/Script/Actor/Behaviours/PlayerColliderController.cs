using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    void OnTriggerEnter2D(Collider2D other)
    {
       
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
        if (other.tag == "Weapon" && Input.GetKey(InputManager.Instance.ActiveObject))
        {
            gameObject.GetComponent<ActorWeapon>().ChangeActorWeapon(other.gameObject);

        }


    }

}
