using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStats : MonoBehaviour
{
    public float MaxHP;
    public float curHP;
    public float speed;
    public float attackSpeed;
    public bool IsFaceingRight = true;

    public Vector2 MoveDirection;
    public Rigidbody2D rigidbodyCharactor; 

    void Awake(){
        rigidbodyCharactor = gameObject.GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ControllActor();
    }

    // public void ControllActor()
    // {
    //     if (isActorDeath == false)
    //     {
    //         MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    //         MoveDirection.Normalize();
    //         rigidbodyCharactor.velocity = MoveDirection * MoveSpeed;
    //         if (MoveDirection != Vector2.zero)
    //         {
    //             ObserverManager.Notify("Player Move");

    //         }
    //         
    //     }
    //     else return;
    // }
    public void CheckForLeftOrRightFacing(Vector2 velocity){
        if (IsFaceingRight && velocity.x < 0f)
            {
                Vector3 rotator = new Vector3(transform.rotation.x, 180, transform.rotation.z);
                transform.rotation = Quaternion.Euler(rotator);
                IsFaceingRight = !IsFaceingRight;
            }
            else if (!IsFaceingRight && velocity.x > 0f)
            {
                Vector3 rotator = new Vector3(transform.rotation.x, 0, transform.rotation.z);
                transform.rotation = Quaternion.Euler(rotator);
                IsFaceingRight = !IsFaceingRight;
            }
    }
    public void ControllActor(){
        MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveDirection.Normalize();
        rigidbodyCharactor.velocity = MoveDirection * speed;
        CheckForLeftOrRightFacing(rigidbodyCharactor.velocity);
    }
}
