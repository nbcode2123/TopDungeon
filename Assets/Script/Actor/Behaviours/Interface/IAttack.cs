using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{

    LayerMask AttackableLayer { set; get; }
    float AttackDmg { set; get; }

}
