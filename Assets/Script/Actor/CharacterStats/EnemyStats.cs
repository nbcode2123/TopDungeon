using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IMovement, IAttackable, IHeath
{
    public float movementSpeed;
    public float MovementSpeed
    {
        get => movementSpeed;
        set => movementSpeed = value;
    }
    public float attackSpeed;
    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }
    public int attackDamage;
    public int AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }
    public int maxHeath;
    public int MaxHeath
    {
        get => maxHeath;
        set => maxHeath = value;
    }
    public int currentHeath;
    public int CurrentHeath
    {
        get => currentHeath;
        set => currentHeath = value;
    }

    public event Action OnMovement;
    public event Action OnStopMovement;

    public void DecreaseAttackDamage(int value)
    {
        throw new NotImplementedException();
    }

    public void DecreaseAttackSpeed(int value)
    {
        throw new NotImplementedException();
    }

    public void DecreaseMovementSpeed(float value)
    {
        throw new NotImplementedException();
    }

    public int GetAttackDamage()
    {
        return AttackDamage;
    }

    public float GetAttackSpeed()
    {
        return AttackSpeed;
    }

    public float GetMovementSpeed()
    {
        throw new NotImplementedException();
    }

    public void IncreaseAttackDamage(int value)
    {
        throw new NotImplementedException();
    }

    public void IncreaseAttackSpeed(int value)
    {
        throw new NotImplementedException();
    }

    public void IncreaseMovementSpeed(float value)
    {
        throw new NotImplementedException();
    }

    public void Move(float MoveSpeed)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetCurrentHeath()
    {
        return CurrentHeath;
    }

    public int GetMaxHeath()
    {
        throw new NotImplementedException();
    }

    public void DecreaseCurrentHeath(int value)
    {
        CurrentHeath -= value;
    }

    public void IncreaseCurrentHeath(int value)
    {
        throw new NotImplementedException();
    }

    public void DecreaseMaxHeath(int value)
    {
        throw new NotImplementedException();
    }

    public void IncreaseMaxHeath(int value)
    {
        throw new NotImplementedException();
    }
}
