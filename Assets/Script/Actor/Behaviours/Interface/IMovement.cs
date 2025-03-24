using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    float MoveSpeed { set; get; }
    void Move(float moveSpeed);
    public event Action OnMovement;
    public event Action OnStopMovement;
}
