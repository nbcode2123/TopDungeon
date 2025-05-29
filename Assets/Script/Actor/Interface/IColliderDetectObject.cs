using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColliderDetectObject
{
    public event Action<GameObject> DetectObject;
}
