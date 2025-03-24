
using System;
using UnityEngine;

public class MovePlayer : MonoBehaviour, IMovement
{
    [SerializeField] private Vector2 MoveDirection { get; set; }
    private Rigidbody2D rigidbodyCharactor { get; set; }
    public KeyCode DefaultAttackBtn { get; set; } = KeyCode.Mouse0;
    private bool IsFaceingRight { get; set; } = true;
    public float moveSpeed { get; set; }
    float IMovement.MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public event Action OnMovement;
    public event Action OnStopMovement;

    void OnEnable()
    {
        moveSpeed = gameObject.GetComponent<CharactorStats>().MoveSpeed;


    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyCharactor = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ControllActor();
    }
    public void ControllActor()
    {
        Move(moveSpeed);
    }
    public void Move(float moveSpeed)
    {
        MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (MoveDirection == Vector2.zero)
        {
            OnStopMovement?.Invoke();
        }
        else
        {
            OnMovement?.Invoke();
            Vector2 moveDirection = new Vector2(MoveDirection.x, MoveDirection.y).normalized;
            rigidbodyCharactor.MovePosition(rigidbodyCharactor.position + moveDirection * Time.fixedDeltaTime * moveSpeed);
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
}
