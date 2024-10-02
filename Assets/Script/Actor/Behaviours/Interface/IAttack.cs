using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    // Transform attackTranform { set; get; }
    // float attackRange { set; get; }
    LayerMask AttackableLayer { set; get; }
    RaycastHit2D[] hits { set; get; }
    float AttackDmg { set; get; }
}
