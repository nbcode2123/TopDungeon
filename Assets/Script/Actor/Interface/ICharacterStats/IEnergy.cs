using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnergy
{
    int MaxEnergy { set; get; }
    int CurrentEnergy { set; get; }
    float TimeRecoverEnergy { set; get; }
    int GetCurrentEnergy();
    void DecreaseCurrentEnergy(int value);
    void IncreaseCurrentEnergy(int value);
    void IncreaseMaxEnergy(int value);
    void DecreaseMaxEnergy(int value);
    void RecoveryEnergy();


}
