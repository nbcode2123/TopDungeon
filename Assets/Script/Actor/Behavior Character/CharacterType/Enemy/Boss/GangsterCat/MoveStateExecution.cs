using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MoveStateExecution : MonoBehaviour
{
    [SerializeField] private GameObject Pivot;
    private GameObject Player;
    [SerializeField] private GameObject Actor;
    private Rigidbody2D rb;
    private float MovementSpeed;


    public void Move()
    {
        var _pivotPos = Pivot.transform.position;
        var _playerPos = Player.transform.position;
        var _direction = (_playerPos - _pivotPos).normalized;
        rb.velocity = MovementSpeed * _direction;




    }
    // Start is called before the first frame update
    void Start()
    {
        rb = Actor.GetComponent<Rigidbody2D>();
        IMovement movementStats = Actor.GetComponent<IMovement>();
        MovementSpeed = movementStats.GetMovementSpeed();
    }
    public void SetPlayer(GameObject player)
    {
        Player = player;
    }
    public void StopMovement()
    {
        rb.velocity = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
