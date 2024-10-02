using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMeleeAttacker : IAttack
{
    public Transform AttackTranform { set; get; }
    public float AttackRange { set; get; }

}
