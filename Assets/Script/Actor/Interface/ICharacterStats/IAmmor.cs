using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmmor
{
    int MaxAmmor { set; get; }
    int CurrentAmmor { set; get; }
    float TimeRecoverAmmor { set; get; }
    int GetCurrentAmmor();
    void DecreaseCurrentAmmor(int value);
    void IncreaseCurrentAmmor(int value);
    void IncreaseMaxAmmor(int value);
    void DecreaseMaxAmmor(int value);
    void RecoveryAmmor();
}
