using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHeath
{
    int MaxHeath { set; get; }
    int CurrentHeath { set; get; }
    int GetCurrentHeath();
    int GetMaxHeath();
    void DecreaseCurrentHeath(int value);
    void IncreaseCurrentHeath(int value);
    void DecreaseMaxHeath(int value);
    void IncreaseMaxHeath(int value);





}
