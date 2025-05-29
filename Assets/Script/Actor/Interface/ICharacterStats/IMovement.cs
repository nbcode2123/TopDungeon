using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    float MovementSpeed { set; get; }
    void IncreaseMovementSpeed(float value);
    void DecreaseMovementSpeed(float value);
    float GetMovementSpeed();
    void Move(float MoveSpeed);
    public event Action OnMovement;
    public event Action OnStopMovement;
}
