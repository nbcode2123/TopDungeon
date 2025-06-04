using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IHeath, IMovement
{
    [SerializeField]
    private int maxHeath;
    public int MaxHeath
    {
        get => maxHeath;
        set => maxHeath = value;
    }
    [SerializeField]
    private int currentHeath;
    public int CurrentHeath
    {
        get => currentHeath;
        set => currentHeath = value;
    }
    [SerializeField]
    private float movementSpeed;

    public event Action OnMovement;
    public event Action OnStopMovement;

    public float MovementSpeed
    {
        get => movementSpeed;
        set => movementSpeed = value;
    }





    public void DecreaseCurrentHeath(int value)
    {
        if (value <= CurrentHeath)
        {
            CurrentHeath -= value;

        }
        else if (value > CurrentHeath)
        {
            CurrentHeath = 0;
        }

    }

    public void DecreaseMaxHeath(int value)
    {

    }

    public void DecreaseMovementSpeed(float value)
    {

    }


    public int GetCurrentHeath()
    {
        return CurrentHeath;

    }

    public int GetMaxHeath()
    {
        return MaxHeath;

    }

    public float GetMovementSpeed()
    {
        return MovementSpeed;

    }

    public void IncreaseAttackDamage(int value)
    {

    }

    public void IncreaseAttackSpeed(int value)
    {

    }

    public void IncreaseCurrentHeath(int value)
    {

    }

    public void IncreaseMaxHeath(int value)
    {

    }

    public void IncreaseMovementSpeed(float value)
    {

    }
    // Start is called before the first frame update
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {

    }

    void OnEnable()
    {
        CurrentHeath = MaxHeath;
    }

    public void Move(float MoveSpeed)
    {
        throw new NotImplementedException();
    }
}
