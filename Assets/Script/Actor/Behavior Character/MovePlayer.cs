
using System;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour, IMovement
{
    [SerializeField] private Vector2 MoveDirection { get; set; }
    private Rigidbody2D rigidbodyCharactor { get; set; }
    public KeyCode DefaultAttackBtn { get; set; } = KeyCode.Mouse0;
    private bool IsFaceingRight { get; set; } = true;
    public float movementSpeed;
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }

    public event Action OnMovement;
    public event Action OnStopMovement;
    public bool DeathFlag = false;

    void OnEnable()
    {
        MovementSpeed = gameObject.GetComponent<IMovement>().GetMovementSpeed();


    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyCharactor = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DeathFlag == false)
        {
            ControllActor();

        }
    }
    public void ControllActor()
    {
        Move(MovementSpeed);
    }
    public void Move(float MovementSpeed)
    {

        MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (MoveDirection == Vector2.zero)
        {
            OnStopMovement?.Invoke();
        }
        else
        {
            MovementSpeed = gameObject.GetComponent<CharacterStats>().GetMovementSpeed();
            OnMovement?.Invoke();
            Vector2 moveDirection = new Vector2(MoveDirection.x, MoveDirection.y).normalized;
            rigidbodyCharactor.MovePosition(rigidbodyCharactor.position + moveDirection * Time.fixedDeltaTime * MovementSpeed);
            CheckForLeftOrRightFacing();
        }

    }
    public void CheckForLeftOrRightFacing()
    {
        if (IsFaceingRight && MoveDirection.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFaceingRight = !IsFaceingRight;
        }
        else if (!IsFaceingRight && MoveDirection.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFaceingRight = !IsFaceingRight;
        }
    }

    public void IncreaseMovementSpeed(float value)
    {
        throw new NotImplementedException();
    }

    public void DecreaseMovementSpeed(float value)
    {
        throw new NotImplementedException();
    }

    public float GetMovementSpeed()
    {
        return MovementSpeed;
    }
}
