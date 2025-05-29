using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRangeWeapon : IWeapon
{
    GameObject Bullet { get; set; }
    void CreateAmmo();

}
