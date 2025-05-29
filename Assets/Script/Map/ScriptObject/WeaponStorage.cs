using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponStorage", menuName = "WeaponStorage", order = 0)]

public class WeaponStorage : ScriptableObject
{
    public List<GameObject> CommonWeapon;
    public List<GameObject> RareWeapon;
    public List<GameObject> EpicWeapon;
    public float CommonRate;
    public float RareRate;
    public float EpicRate;


}
