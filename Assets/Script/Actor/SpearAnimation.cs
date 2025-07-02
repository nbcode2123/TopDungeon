using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAnimation : MonoBehaviour
{
    public Animator spearAnimator;
    public Animator spearEffectAnimator;
    public IWeapon WeaponStats;
    public GameObject Weapon;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        WeaponStats = Weapon.GetComponent<IWeapon>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // other.gameObject.GetComponent<IDamageable>()?.TakeDamage(WeaponStats.WeaponDamage);
        Target = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Target = null;
    }
    public void StrikeObj()
    {
        if (Target != null)
        {
            Target.GetComponent<IDamageable>()?.TakeDamage(WeaponStats.WeaponDamage);

        }
    }

}
