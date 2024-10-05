using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AllowControllActor : MonoBehaviour
{
    public Vector2 MoveDirection { get; set; }
    private Rigidbody2D rigidbodyCharactor { get; set; }
    public KeyCode DefaultAttackBtn { get; set; } = KeyCode.Mouse0;
    public bool IsFaceingRight { get; set; } = true;
    public bool isActorDeath { get; set; }
    public float MoveSpeed;
    private IActorStats ActorStats;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyCharactor = gameObject.GetComponent<Rigidbody2D>();
        if (gameObject.GetComponent<IActorStats>() != null)
        {
            ActorStats = gameObject.GetComponent<IActorStats>();
            MoveSpeed = ActorStats.MoveSpeed;
        }
        else MoveSpeed = 10f;





    }
    // Update is called once per frame
    void Update()
    {
        isActorDeath = gameObject.GetComponent<PlayerStates>().isDeath;

        ControllActor();
    }
    public void ControllActor()
    {
        if (isActorDeath == false)
        {
            MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            MoveDirection.Normalize();
            rigidbodyCharactor.velocity = MoveDirection * MoveSpeed;
            if (MoveDirection != Vector2.zero)
            {
                ObserverManager.Notify("Player Move");

            }
            CheckForLeftOrRightFacing(rigidbodyCharactor.velocity);
        }
        else return;
    }
    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
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
}
