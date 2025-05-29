using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColliderTrigger
{
    public event Action OnEnterTrigger;
    public event Action OnExitTrigger;
    public event Action OnStayTrigger;
}
