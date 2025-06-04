
using UnityEngine;

public class BarrelStats : MonoBehaviour, IAttackable, IHeath
{
    public int attackDamage;
    public int AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }
    public int currentHeath;
    public int CurrentHeath
    {
        get => currentHeath;
        set => currentHeath = value;
    }
    public int maxHeath;
    public int MaxHeath
    {
        get => maxHeath;
        set => maxHeath = value;
    }
    public float attackSpeed;
    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    public void DecreaseAttackDamage(int value)
    {
        throw new System.NotImplementedException();
    }


    public void DecreaseAttackSpeed(int value)
    {
        throw new System.NotImplementedException();
    }

    public void DecreaseCurrentHeath(int value)
    {
        CurrentHeath -= value;
    }

    public void DecreaseMaxHeath(int value)
    {
        throw new System.NotImplementedException();
    }

    public int GetAttackDamage()
    {
        return AttackDamage;
    }

    public float GetAttackSpeed()
    {
        throw new System.NotImplementedException();
    }

    public int GetCurrentHeath()
    {
        return CurrentHeath;

    }

    public int GetMaxHeath()
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseAttackDamage(int value)
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseAttackSpeed(int value)
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseCurrentHeath(int value)
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseMaxHeath(int value)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
