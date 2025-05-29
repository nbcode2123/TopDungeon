using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeathState
{
    BaseState DeathState { set; get; }
    void ChangeToDeathState();

}
