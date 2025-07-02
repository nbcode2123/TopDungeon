using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats, IAmmor, IEnergy
{
    [SerializeField]
    private string nameCharacter;
    public string NameCharacter
    {
        get => nameCharacter;
        set => nameCharacter = value;
    }


    public GameObject BaseWeapon;

    //  public int MaxAmmor;
    //  public int MaxEnergy;
    //  public int CurrentAmmor;

    //  public int CurrentEnergy;
    //  public int TimeRecoverAmmor;
    //  public int TimeRecoverEnergy;
    private bool isRegenAmmor = false;
    private bool isRengenEnergy = false;


    [SerializeField]
    private int maxAmmor;
    public int MaxAmmor
    {
        get => maxAmmor;
        set => maxAmmor = value;
    }

    [SerializeField]
    private int currentAmmor;
    public int CurrentAmmor
    {
        get => currentAmmor;
        set => currentAmmor = value;
    }
    [SerializeField]
    private float timeRecoverAmmor;
    public float TimeRecoverAmmor
    {
        get => timeRecoverAmmor;
        set => timeRecoverAmmor = value;
    }

    [SerializeField]
    private int maxEnergy;

    public int MaxEnergy
    {
        get => maxEnergy;
        set => maxEnergy = value;
    }
    [SerializeField]
    private int currentEnergy;

    public int CurrentEnergy
    {
        get => currentEnergy;
        set => currentEnergy = value;
    }
    [SerializeField]
    private float timeRecoverEnergy;

    public float TimeRecoverEnergy
    {
        get => timeRecoverEnergy;
        set => timeRecoverEnergy = value;
    }












    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        CurrentAmmor = MaxAmmor;
        CurrentEnergy = MaxEnergy;

        // gameObject.GetComponent<WeaponController>().ActorWeapon = BaseWeapon;
        // gameObject.GetComponent<WeaponController>().InitializeWeapon();

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (CurrentAmmor < MaxAmmor && !isRegenAmmor)
        {
            StartCoroutine(RegenAmmor());
        }
        if (CurrentEnergy < MaxEnergy && !isRengenEnergy)
        {
            StartCoroutine(RegenEnergy());
        }



    }
    public IEnumerator RegenAmmor()
    {
        isRegenAmmor = true;
        yield return new WaitForSeconds(TimeRecoverAmmor);
        CurrentAmmor++;
        UIManager.Instance.PlayerStatsAmmorUpdate(CurrentAmmor);
        isRegenAmmor = false;


    }
    public IEnumerator RegenEnergy()
    {
        isRengenEnergy = true;
        yield return new WaitForSeconds(TimeRecoverEnergy);


        CurrentEnergy++;
        UIManager.Instance.PlayerStatsEnergyUpdate(CurrentEnergy);

        isRengenEnergy = false;


    }
    public void UsingEnergy(int Energy)
    {
        CurrentEnergy -= Energy;
        UIManager.Instance.PlayerStatsEnergyUpdate(CurrentEnergy);

    }
    public int GetMaxAmmor()
    {
        return MaxAmmor;
    }

    public int GetCurrentAmmor()
    {
        return CurrentAmmor;

    }
    public string GetNameCharacter()
    {
        return NameCharacter;
    }

    public void DecreaseCurrentAmmor(int value)
    {
        if (value <= CurrentAmmor)
        {
            CurrentAmmor -= value;

        }
        else if (value > CurrentAmmor)
        {
            CurrentAmmor = 0;
        }

    }

    public void IncreaseCurrentAmmor(int value)
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseMaxAmmor(int value)
    {
        MaxAmmor += value;
        if (MaxAmmor < 0)
        {
            MaxAmmor = 0;

        }
        if (MaxAmmor < CurrentAmmor)
        {
            CurrentAmmor = MaxAmmor;
        }
        UIManager.Instance.PlayerStatsMaxAmmorUpdate(MaxAmmor);
        UIManager.Instance.PlayerStatsAmmorUpdate(CurrentAmmor);

    }

    public void DecreaseMaxAmmor(int value)
    {
        throw new System.NotImplementedException();
    }

    public void RecoveryAmmor()
    {
        throw new System.NotImplementedException();
    }

    public int GetCurrentEnergy()
    {
        return CurrentEnergy;
    }
    public int GetMaxEnergy()
    {
        return MaxEnergy;
    }

    public void DecreaseCurrentEnergy(int value)
    {
        if (value <= CurrentEnergy)
        {
            CurrentEnergy -= value;
            UIManager.Instance.PlayerStatsEnergyUpdate(CurrentEnergy);


        }
        else if (value > CurrentEnergy)
        {
            CurrentEnergy = 0;
            UIManager.Instance.PlayerStatsEnergyUpdate(CurrentEnergy);


        }

    }

    public void IncreaseCurrentEnergy(int value)
    {
        CurrentEnergy += value;
        UIManager.Instance.PlayerStatsEnergyUpdate(CurrentEnergy);
        if (CurrentEnergy > MaxEnergy)
        {
            CurrentEnergy = MaxEnergy;
            UIManager.Instance.PlayerStatsEnergyUpdate(CurrentEnergy);

        }
    }

    public void IncreaseMaxEnergy(int value)
    {
        throw new System.NotImplementedException();
    }

    public void DecreaseMaxEnergy(int value)
    {
        throw new System.NotImplementedException();
    }

    public void RecoveryEnergy()
    {
        throw new System.NotImplementedException();
    }
}
