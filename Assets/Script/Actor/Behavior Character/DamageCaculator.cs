
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DamageCalculator : MonoBehaviour, IDamageable
{
    public event Action OnDamage;
    public event Action OnDeath;
    public virtual void TakeDamage(int damage)
    {
        var _characterStats = gameObject.GetComponent<IHeath>();
        // Debug.Log(gameObject.name + "bi dmg ");
        if (_characterStats.GetCurrentHeath() >= damage)
        {
            _characterStats.DecreaseCurrentHeath(damage);
            OnDamage?.Invoke();


        }
        if (_characterStats.GetCurrentHeath() <= damage)
        {
            _characterStats.DecreaseCurrentHeath(damage);
            InvokeOnDeath();
            // gameObject.GetComponent<Animator>()?.Play("Death");
            Debug.Log(gameObject.name + " chet ");
            // gameObject.SetActive(false); //! se sua lai viec enemy disable sau 


        }

    }
    protected void InvokeOnDeath()
    {
        OnDeath?.Invoke();
    }
}
